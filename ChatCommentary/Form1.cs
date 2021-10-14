using System;
using System.Windows.Forms;
using TwitchLib.PubSub;
using TwitchLib.PubSub.Events;
using TwitchLib.Api;
using System.IO;
using System.Media;
using System.Collections.Generic;
using System.Linq;

namespace ChatCommentaryApp
{
    public partial class ChatCommentaryForm : Form
    {
        private static TwitchPubSub client;
        private static TwitchAPI api;
        private static SoundPlayer soundPlayer;
        private static List<string> directories = new List<string>();

        public ChatCommentaryForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new TwitchPubSub();

            client.OnPubSubServiceConnected += OnPubSubServiceConnected;
            client.OnListenResponse += OnListenResponse;
            client.OnChannelPointsRewardRedeemed += OnChannelPointsRewardRedeemed;
            client.ListenToChannelPoints(Properties.Settings.Default.ChannelID);
            client.Connect();

            api = new TwitchAPI();

            api.Settings.ClientId = Properties.Settings.Default.ClientID;
            api.Settings.AccessToken = Properties.Settings.Default.AccessToken;

            if (File.Exists("settings.txt"))
            {
                String[] loadSettings = File.ReadAllLines("settings.txt");
                foreach (string line in loadSettings)
                {
                    directories.Add(line);
                }
            }

            CreateReward();

            ReloadListItems();
        }

        private static void OnPubSubServiceConnected(object sender, EventArgs e)
        {
            client.SendTopics(Properties.Settings.Default.AccessToken);
        }

        private static void OnListenResponse(object sender, OnListenResponseArgs e)
        {
            if (!e.Successful)
                throw new Exception($"Failed to listen! Response: {e.Response}");
        }

        private void OnChannelPointsRewardRedeemed(object sender, OnChannelPointsRewardRedeemedArgs e)
        {
            if (e.RewardRedeemed.Redemption.Reward.Id == Properties.Settings.Default.RewardID && e.RewardRedeemed.Redemption.Status != "ACTION_TAKEN")
            {
                var rand = new Random();
                List<string> files = new List<string>();
                foreach (string directory in directories)
                {
                    files.AddRange(Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories).Where(s => s.EndsWith(".mp3") || s.EndsWith(".wav")));
                }
                PlaySound(files[rand.Next(files.Count)]);
            }
        }

        public void PlaySound(string filename, EventHandler doneCallback = null)
        {

            using (soundPlayer = new SoundPlayer())
            {
                soundPlayer.SoundLocation = filename;
                soundPlayer.Load();
                soundPlayer.PlaySync();
            }
            doneCallback?.Invoke(this, new EventArgs());
        }

        private void ReloadListItems()
        {
            directoryListBox.Items.Clear();

            foreach (string directory in directories)
            {
                directoryListBox.Items.Add(directory);
            }
            SaveDirectories();
        }

        private void SaveDirectories()
        {
            string buildString = "";
            foreach (string directory in directories)
            {
                buildString += directory + "\n";
            }
            File.WriteAllText(("settings.txt"), buildString);
        }

        private void AddDirectoryButton_Clicked(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    string filePath = folderBrowserDialog.SelectedPath;
                    if (directories.Contains(filePath) == false)
                    {
                        directories.Add(filePath);
                        ReloadListItems();
                    }
                }
            }
        }

        private void RemoveDirectoryButton_Clicked(object sender, EventArgs e)
        {
            directories.Remove(directoryListBox.SelectedItem.ToString());
            ReloadListItems();
        }

        private async void EnabledCheckbox_Changed(object sender, EventArgs e)
        {
            TwitchLib.Api.Helix.Models.ChannelPoints.UpdateCustomReward.UpdateCustomRewardRequest updateCustomRewardRequest = new TwitchLib.Api.Helix.Models.ChannelPoints.UpdateCustomReward.UpdateCustomRewardRequest
            {
                IsEnabled = enableRewardCheckbox.Checked
            };
            await api.Helix.ChannelPoints.UpdateCustomReward(Properties.Settings.Default.ChannelID, Properties.Settings.Default.RewardID, updateCustomRewardRequest);
        }

        private async void UpdateButton_Clicked(object sender, EventArgs e)
        {
            TwitchLib.Api.Helix.Models.ChannelPoints.UpdateCustomReward.UpdateCustomRewardRequest updateCustomRewardRequest = new TwitchLib.Api.Helix.Models.ChannelPoints.UpdateCustomReward.UpdateCustomRewardRequest
            {
                Title = titleBox.Text,
                Cost = Convert.ToInt32(costBox.Text)
            };
            Properties.Settings.Default.Title = titleBox.Text;
            Properties.Settings.Default.Cost = costBox.Text;
            Properties.Settings.Default.Save();
            await api.Helix.ChannelPoints.UpdateCustomReward(Properties.Settings.Default.ChannelID, Properties.Settings.Default.RewardID, updateCustomRewardRequest);
        }
        private async void ExitButton_Clicked(object sender, EventArgs e)
        {
            await api.Helix.ChannelPoints.DeleteCustomReward(Properties.Settings.Default.ChannelID, Properties.Settings.Default.RewardID);
            Application.Exit();
        }

        private async void CreateReward()
        {
            TwitchLib.Api.Helix.Models.ChannelPoints.CreateCustomReward.CreateCustomRewardsRequest createCustomRewardsRequest = new TwitchLib.Api.Helix.Models.ChannelPoints.CreateCustomReward.CreateCustomRewardsRequest
            {
                Title = Properties.Settings.Default.Title,
                Cost = Convert.ToInt32(Properties.Settings.Default.Cost),
                IsEnabled = false,
                ShouldRedemptionsSkipRequestQueue = true
            };
            TwitchLib.Api.Helix.Models.ChannelPoints.CreateCustomReward.CreateCustomRewardsResponse createCustomRewardsResponse = await api.Helix.ChannelPoints.CreateCustomRewards(Properties.Settings.Default.ChannelID, createCustomRewardsRequest);
            Properties.Settings.Default.RewardID = createCustomRewardsResponse.Data[0].Id;
            enableRewardCheckbox.Checked = createCustomRewardsResponse.Data[0].IsEnabled;
            costBox.Text = createCustomRewardsResponse.Data[0].Cost.ToString();
            titleBox.Text = createCustomRewardsResponse.Data[0].Title;
            Properties.Settings.Default.Save();
        }

    }
}
