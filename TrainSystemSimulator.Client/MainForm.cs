using BlueStacks.Core.BusinessLogic;
using BlueStacks.Core.BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bluestacks.Client
{
    public partial class MainForm : Form
    {

        static int _noOfStations = 8;
        static int _noOfTrains = 4;
        static int[] _speeds = new Int32[_noOfTrains];
        static int[] _distances = new Int32[_noOfStations];
        static int[] _shipmentCapacity = new Int32[_noOfTrains];
        static int _timer = 1;
        private SynchronizationContext _synchronizationContext;

        public MainForm()
        {
            _synchronizationContext = WindowsFormsSynchronizationContext.Current;
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            // Initialize default random shipment capacity
            InitializeDefaultShipmentCapacity();

            // Update UI with generated data
            UpdateUIComponents();

            BindEventsForUIUpdated();
        }

        /// <summary>
        /// Initialize random shipment
        /// </summary>
        private void InitializeDefaultShipmentCapacity()
        {
            try
            {
                Random randomNumberGenerator = new Random();
                for (int i = 0; i < _noOfTrains; i++)
                {
                    _shipmentCapacity[i] = randomNumberGenerator.Next(5, 20);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);    
            }
        }

        private void UpdateUIComponents()
        {
            try
            {
                txbNoOfStations.Text = _noOfStations.ToString();
                txbNoOfTrains.Text = _noOfTrains.ToString();
                txbTimer.Text = _timer.ToString();
                GenerateShipmentPanel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GenerateShipmentPanel()
        {
            try
            {
                int pointX = 3;
                int pointY = 4;
                pnlShipmentCapacity.Controls.Clear();
                for (int i = 0; i < _noOfTrains; i++)
                {
                    TextBox txbShipment = new TextBox();
                    if (_shipmentCapacity.Count() - 1 >= i)
                        txbShipment.Text = _shipmentCapacity[i].ToString();
                    else
                        txbShipment.Text = "0";
                    txbShipment.Location = new Point(pointX, pointY);
                    txbShipment.Width = pnlShipmentCapacity.Width - 8;
                    txbShipment.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
                    pnlShipmentCapacity.Controls.Add(txbShipment);
                    pnlShipmentCapacity.Show();
                    pointY += 30;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void BindEventsForUIUpdated()
        {
            try
            {
                StationShipmentHandler.ShipmentQueuedAtStation += UpdateShipmentQueuingAtStation;
                TrainSystemSimulator.TrainProgressEvent += UpdateTrackIdWithTrainProgress;
                TrainSystemSimulator.TrainShipmentLoadEvent += UpdateShipmentLoadedIntoTrainProgress;
                TrainSystemSimulator.TrainShipmentUnloadEvent += UpdateShipmentUnloadedFromTrainProgress;
                TrainSystemSimulator.TrainArrivedAtStationEvent += UpdateTrainArrivalAtUI;
                TrainSystemSimulator.TrainOtherEvent += UpdateTrainOtherEventsAtUI;
                Station.ShipmentDequeuedFromStation += UpdateShipmentDequeueFromStation;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateTrainOtherEventsAtUI(object sender, TrainProcessEventArgs e)
        {
            try
            {
                _synchronizationContext.Post((evnt) =>
                {
                    try
                    {
                        var evntargs = (evnt as TrainProcessEventArgs);
                        if (evnt != null && tvwTrains != null)
                        {
                            foreach (TreeNode node in tvwTrains.Nodes[0].Nodes)
                            {
                                if (node.Text.Contains(evntargs.TrainId))
                                {
                                    if (node.Nodes.Count > 0)
                                    {
                                        if (node.Nodes[0].Tag == null || string.IsNullOrEmpty(node.Nodes[0].Tag.ToString()))
                                        {
                                            node.Nodes[0].Text = evntargs.Message;
                                        }
                                        else
                                        {
                                            TreeNode newChildNode = new TreeNode(evntargs.Message);
                                            TreeNodeCollection nodes = node.Nodes;
                                            node.Nodes.Clear();
                                            node.Nodes.Add(newChildNode);
                                            foreach (TreeNode existingNode in nodes)
                                            {
                                                node.Nodes.Add(existingNode);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        TreeNode newChildNode = new TreeNode(evntargs.Message);
                                        node.Nodes.Add(newChildNode);
                                    }
                                }
                            }
                        }
                        tvwTrains.ExpandAll();
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                    }

                }, e);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void UpdateShipmentUnloadedFromTrainProgress(object sender, TrainProcessEventArgs e)
        {
            try
            {
                _synchronizationContext.Post((evnt) =>
                {
                    try
                    {
                        var evntargs = (evnt as TrainProcessEventArgs);
                        if (evnt != null && tvwTrains != null)
                        {
                            foreach (TreeNode node in tvwTrains.Nodes[0].Nodes)
                            {
                                if (node.Text.Contains(evntargs.TrainId))
                                {

                                    if (node.Nodes.Count > 0)
                                    {
                                        TreeNode nodeToRemove = null;
                                        foreach (TreeNode shipmentNode in node.Nodes)
                                        {
                                            if (shipmentNode.Tag != null && shipmentNode.Tag.ToString().Equals(evntargs.DeliveredShipment.ShipmentIdentifier))
                                            {
                                                nodeToRemove = shipmentNode;
                                                break;
                                            }
                                        }
                                        if (nodeToRemove != null)
                                        {
                                            node.Nodes.Remove(nodeToRemove);
                                        }
                                    }
                                }
                            }
                        }
                        tvwTrains.ExpandAll();
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                    }

                }, e);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void UpdateShipmentLoadedIntoTrainProgress(object sender, TrainProcessEventArgs e)
        {
            try
            {
                _synchronizationContext.Post((evnt) =>
                {
                    try
                    {
                        var evntargs = (evnt as TrainProcessEventArgs);
                        if (evnt != null && tvwTrains != null)
                        {
                            foreach (TreeNode node in tvwTrains.Nodes[0].Nodes)
                            {
                                if (node.Text.Contains(evntargs.TrainId))
                                {
                                    TreeNode newChildNode = new TreeNode(evntargs.Message);
                                    node.Nodes.Add(newChildNode);
                                }
                            }
                        }
                        tvwTrains.ExpandAll();
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                    }

                }, e);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void UpdateShipmentDequeueFromStation(object sender, StationShipmentEventArgs e)
        {
            try
            {
                _synchronizationContext.Post((evnt) =>
                {
                    try
                    {
                        var evntargs = (evnt as StationShipmentEventArgs);
                        if (evnt != null && tvwTrains != null)
                        {
                            foreach (TreeNode node in tvwStations.Nodes[0].Nodes)
                            {
                                if (node.Text.Contains("Station" + evntargs.SourceStationNumber))
                                {

                                    if (node.Nodes.Count > 0)
                                    {
                                        TreeNode nodeToRemove = null;
                                        foreach (TreeNode shipmentNode in node.Nodes)
                                        {
                                            if (shipmentNode.Tag.ToString().Contains(evntargs.DeliveredShipment.ShipmentIdentifier.ToString()))
                                            {
                                                nodeToRemove = shipmentNode;
                                                break;
                                            }
                                        }
                                        if (nodeToRemove != null)
                                        {
                                            node.Nodes.Remove(nodeToRemove);
                                        }
                                    }
                                }
                            }
                        }
                        tvwStations.ExpandAll();
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                    }

                }, e);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void UpdateTrainArrivalAtUI(object sender, TrainProcessEventArgs e)
        {
            try
            {
                _synchronizationContext.Post((evnt) =>
                {
                    try
                    {
                        var evntargs = (evnt as TrainProcessEventArgs);
                        if (evnt != null && tvwTracks != null)
                        {
                            foreach (TreeNode node in tvwTracks.Nodes[0].Nodes)
                            {
                                if (node.Text.Contains(evntargs.TrackId))
                                {
                                    if (node.Nodes.Count > 0)
                                    {
                                        node.Nodes.Clear();
                                    }
                                }
                            }
                        }
                        tvwTracks.ExpandAll();
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                    }

                }, e);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void UpdateTrackIdWithTrainProgress(object sender, TrainProcessEventArgs e)
        {
            try
            {
                _synchronizationContext.Post((evnt) =>
                {
                    try
                    {
                        var evntargs = (evnt as TrainProcessEventArgs);
                        if (evnt != null && tvwTracks != null)
                        {
                            foreach (TreeNode node in tvwTracks.Nodes[0].Nodes)
                            {
                                if (node.Text.Contains(evntargs.TrackId))
                                {
                                    if (node.Nodes.Count > 0)
                                    {
                                        node.Nodes[0].Text = evntargs.Message;
                                    }
                                    else
                                    {
                                        TreeNode newChildNode = new TreeNode(evntargs.Message);
                                        node.Nodes.Add(newChildNode);
                                    }
                                }
                            }
                        }
                        tvwTracks.ExpandAll();
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                    }

                }, e);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void UpdateShipmentQueuingAtStation(object sender, StationShipmentEventArgs e)
        {
            try
            {
                _synchronizationContext.Post((evnt) =>
                {
                    try
                    {
                        var evntargs = (evnt as StationShipmentEventArgs);
                        if (evnt != null && tvwStations != null)
                        {
                            foreach (TreeNode node in tvwStations.Nodes[0].Nodes)
                            {
                                if (node.Text.Equals("Station" + e.SourceStationNumber))
                                {
                                    TreeNode newChildNode = new TreeNode(evntargs.Message);
                                    newChildNode.Tag = evntargs.DeliveredShipment.ShipmentIdentifier;
                                    node.Nodes.Add(newChildNode);
                                }
                            }
                        }
                        tvwStations.ExpandAll();
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                    }

                }, e);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

        }

        private void InitilizeUIComponents()
        {
            // Initialize stations 
            if (tvwStations != null)
            {
                var nodes = tvwStations.Nodes;
                TreeNode rootNode = new TreeNode("All Stations");
                var dicStations = LookupCache.GetInstance().GetStations();
                if (dicStations != null)
                {
                    TreeNode node;
                    foreach (var stationKey in dicStations.Keys)
                    {
                        var station = dicStations[stationKey];
                        node = new TreeNode(station.ToString());
                        rootNode.Nodes.Add(node);
                    }
                }
                nodes.Add(rootNode);
                tvwStations.ExpandAll();
            }

            // Initialize trains 
            if (tvwTrains != null)
            {
                var nodes = tvwTrains.Nodes;
                TreeNode rootNode = new TreeNode("All Trains");
                var lstTrains = LookupCache.GetInstance().GetTrains();
                if (lstTrains != null)
                {
                    TreeNode node;
                    foreach (var train in lstTrains)
                    {
                        node = new TreeNode(train.ToString());
                        rootNode.Nodes.Add(node);
                    }
                }
                nodes.Add(rootNode);
                tvwTrains.ExpandAll();
            }

            // Initialize train tracks 
            if (tvwTracks != null)
            {
                var nodes = tvwTracks.Nodes;
                TreeNode rootNode = new TreeNode("All Train Tracks");
                var dicTracks = LookupCache.GetInstance().GetTracks();
                if (dicTracks != null)
                {
                    TreeNode node;
                    foreach (var key in dicTracks.Keys)
                    {
                        var track = dicTracks[key];
                        node = new TreeNode(track.ToString());
                        rootNode.Nodes.Add(node);
                    }
                }
                nodes.Add(rootNode);
                tvwTracks.ExpandAll();
            }
        }

        /// <summary>
        /// Initilizes trains , tracks, stations, speeds, distances etc
        /// </summary>
        private static void InitializeData()
        {
            try
            {
                // Randomly generating different but constant speeds, shipment capacity & track distances.
                Random randomNumberGenerator = new Random();
                for (int i = 0; i < _noOfStations; i++)
                {
                    _distances[i] = randomNumberGenerator.Next(3, 11) * 10;
                }

                for (int i = 0; i < _noOfTrains; i++)
                {
                    _speeds[i] = randomNumberGenerator.Next(3, 25) * 10;
                }

                // Global cache
                var cache = LookupCache.GetInstance();

                // Initilize train tracks & trains
                Dictionary<string, TrainTrack> _dicTracks = new Dictionary<string, TrainTrack>();

                for (int i = 1; i <= _noOfStations; i++)
                {
                    Station station = new Station(i, "Station" + i.ToString());
                    cache.AddStation(station);
                    if (i == _noOfStations)
                    {
                        String key = "Station" + i.ToString() + "ToStation" + (i + 1).ToString();
                        TrainTrack track = new TrainTrack(i, 1, _distances[i - 1]);
                        _dicTracks.Add(key, track);
                    }
                    else
                    {
                        String key = "Station" + i.ToString() + "To" + "Station1";
                        TrainTrack track = new TrainTrack(i, 1 + i, _distances[i - 1]);
                        _dicTracks.Add(key, track);
                    }
                }

                // adding train tracks to cache
                cache.AddTracks(_dicTracks);

                for (int i = 1; i <= _noOfTrains; i++)
                {
                    Train train = new Train(i, "Train" + i.ToString(), _shipmentCapacity[i - 1], _speeds[i - 1]);
                    cache.AddTrain(train);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CleanUp()
        {
            try
            {
                StationShipmentHandler.ShipmentQueuedAtStation -= UpdateShipmentQueuingAtStation;
                TrainSystemSimulator.TrainProgressEvent -= UpdateTrackIdWithTrainProgress;
                TrainSystemSimulator.TrainShipmentLoadEvent -= UpdateShipmentLoadedIntoTrainProgress;
                TrainSystemSimulator.TrainShipmentUnloadEvent -= UpdateShipmentUnloadedFromTrainProgress;
                TrainSystemSimulator.TrainArrivedAtStationEvent -= UpdateTrainArrivalAtUI;
                TrainSystemSimulator.TrainOtherEvent -= UpdateTrainOtherEventsAtUI;
                Station.ShipmentDequeuedFromStation -= UpdateShipmentDequeueFromStation;
                TrainSystemSimulator.GetInstance().CleanUp();
                StationShipmentHandler.GetInstance().CleanUp();
                GlobalClock.GetInstance().Cleanup();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                StartSimulator();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void StartSimulator()
        {
            try
            {
                ReadSetting();
                InitilizeUIComponents();
                btnSaveSetting.Enabled = false;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void ReadSetting()
        {
            try
            {
                var timer = Convert.ToInt16(txbTimer.Text.Trim());
                if (timer > 0)
                    _timer = timer;
                else
                    MessageBox.Show("Timer should be positive value.");

                var noOfStations = Convert.ToInt16(txbNoOfStations.Text.Trim());
                if (noOfStations > 0)
                    _noOfStations = noOfStations;
                else
                    MessageBox.Show("No of Stations should be positive value.");

                var noOfTrains = Convert.ToInt16(txbNoOfTrains.Text.Trim());
                if (noOfTrains > 0)
                    _noOfTrains = noOfTrains;
                else
                    MessageBox.Show("No of trains should be positive value.");

                int counter = 0;
                _shipmentCapacity = new Int32[_noOfTrains];
                
                foreach (var control in pnlShipmentCapacity.Controls)
                {
                    var txtbox = control as TextBox;
                    if (txtbox != null)
                    {
                        var value = Convert.ToInt32(txtbox.Text.Trim());
                        _shipmentCapacity[counter] = value;
                    }
                    counter++;
                }

                // Reinitialize Random number based on different input values
                _speeds = new Int32[_noOfTrains];
                _distances = new Int32[_noOfStations];
                InitializeData();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                CleanUp();
            }
            catch (Exception)
            {
            }
        }

        private void txbNoOfTrains_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender != null && txbNoOfTrains.Text.Trim().Count() > 0 )
                {
                    var newValue = txbNoOfTrains.Text.Trim();
                    var noOfTrains = Convert.ToInt32(newValue);
                    if (noOfTrains > 0)
                    {
                        _noOfTrains = noOfTrains;
                        GenerateShipmentPanel();
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            
        }

        private void btnStartSimulator_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSaveSetting.Enabled)
                {
                    btnSaveSetting.Enabled = false;
                    StartSimulator();
                }
                GlobalClock.GetInstance().Start(_timer, _noOfStations);
                btnStartSimulator.Enabled = false;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
    }
}
