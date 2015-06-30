using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ITTF_Server
{
    public partial class AdministrationForm : Form
    {
        Administration administration;

        public AdministrationForm()
        {
            InitializeComponent();

            administration = Program._Administration;

            administration.OnStationUpdate += Administration_OnStationUpdate;
            administration.OnTrainUpdate += Administration_OnTrainUpdate;

            //add any objects that have been added to administration before this constructor executed
            foreach (Train train in new List<Train>(administration.Trains))
            {
                Administration_OnTrainUpdate(this, train, true);
            }
            foreach (Station station in new List<Station>(administration.Stations))
            {
                Administration_OnStationUpdate(this, station, true);
            }
        }

        private void Administration_OnTrainUpdate(object sender, Train train, bool add) 
        {
            updateListViewTrains();
            updateListViewWagons();
        }

        private void Administration_OnStationUpdate(object sender, Station station, bool add)
        {
            updateStationListBox();
        }

        private bool AddTrainInternal(int trainNumber, int COM)
        {
            if (administration.FindTrain(trainNumber) == null &&
                administration.Add(new Train (trainNumber, COM)))
            {
                updateListViewTrains();
                return true;
            }
            return false; 
        }

        #region Add Buttons

        private void btnAddWagons_Click(object sender, EventArgs e)
        {
            int wagonNumber;
            int numberOfSeats;
            int numberOfStandingSpots;
            Wagon wagon = null;
            if (!int.TryParse(txtBoxWagonNumber.Text, out wagonNumber) || !int.TryParse(txtBoxSeats.Text, out numberOfSeats)
                || !int.TryParse(txtBoxStandingSpots.Text, out numberOfStandingSpots))
            {
                MessageBox.Show("Invalid input. Please only enter numbers");
            }
            else
            {
                wagon = new Wagon(wagonNumber, numberOfSeats, numberOfStandingSpots);
                Wagon check = administration.FindWagon(wagon.WagonNumber); //find wagon if it already exists 
                if (check == null && wagon != null && administration.Add(wagon)) //add wagon
                {
                    updateListViewWagons();
                }
                else
                {
                    MessageBox.Show("Something went wrong. Could not add Wagon");
                }
            }
        }

        private void btnAddWagonToTrain_Click(object sender, EventArgs e)
        {
            int wagonNumber;
            int trainUnit;
            if (!int.TryParse(cmboBoxWagons.Text, out wagonNumber))
            {
                MessageBox.Show("Invalid input. Please only enter numbers");
            }
            else
            {
                if (lstViewTrains.SelectedItems.Count != 1)
                {
                    MessageBox.Show("Please select a train");
                }
                else
                {
                    if (int.TryParse(lstViewTrains.SelectedItems[0].SubItems[0].Text, out trainUnit))
                    {
                        Train findTrain = administration.FindTrain(trainUnit);
                        Wagon findWagon = administration.FindWagon(wagonNumber);

                        if (findTrain != null && findWagon != null)
                        {
                            if (!WagonInUse(findWagon))
                            {
                                findTrain.Wagons.Add(findWagon);
                                findWagon.AddWagonTo(findTrain); //add wagon to train
                                updateListViewTrains();
                            }
                            else
                            {
                                MessageBox.Show("Wagon is already in use");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Could not find wagon. Wagon not added");
                        }
                    }
                }
            }
        }

        private void btnAddRoute_Click(object sender, EventArgs e)
        {
            int routeNumber;
            int trainUnit;
            string comboBoxText = cmboBoxRoutes.Text;
            string[] splitComboBoxText = comboBoxText.Split(new string[] { "-" }, StringSplitOptions.None);
            string route = splitComboBoxText[0]; //get routeNr

            if (!int.TryParse(route, out routeNumber))
            {
                MessageBox.Show("Invalid input. Please only enter numbers");
            }
            else
            {
                if (lstViewTrains.SelectedItems.Count != 1)
                {
                    MessageBox.Show("Please select a train");
                }
                else
                {
                    if (int.TryParse(lstViewTrains.SelectedItems[0].SubItems[0].Text, out trainUnit))
                    {
                        Train findTrain = administration.FindTrain(trainUnit);
                        Route findRoute = administration.FindRoute(routeNumber);

                        if (findTrain != null && findRoute != null)
                        {
                            findTrain.RouteNr = routeNumber; //set routeNr to train
                            updateListViewTrains();
                        }
                        else
                        {
                            MessageBox.Show("Could not find route. Route not added");
                        }
                    }
                }
            }
        }

        private void btnAddStationToRoute_Click(object sender, EventArgs e)
        {
            int routeNumber;
            if (!int.TryParse(txtBoxRouteNr.Text, out routeNumber))
            {
                MessageBox.Show("Invalid input. Please only enter numbers");
            }
            else
            {
                Route route = null;
                route = new Route(routeNumber);

                Route check = administration.FindRoute(route.RouteNr);
                if (check == null && route != null && administration.Add(route)) //add Route
                {
                    updateListViewRoutes();
                }
                else
                {
                    MessageBox.Show("Something went wrong. Could not add route");
                }
            }
        }

        private void btnAddToRoute_Click_1(object sender, EventArgs e) //add station to route
        {
            string name = cmboBoxStations.Text; //= station string
            int routeNr;
            if (name == "")
            {
                MessageBox.Show("Please enter a valid name");
            }
            else
            {
                if (lstViewRoutes.SelectedItems.Count != 1)
                {
                    MessageBox.Show("Please select a route");
                }
                else
                {
                    if (int.TryParse(lstViewRoutes.SelectedItems[0].SubItems[0].Text, out routeNr))
                    {
                        Station check = administration.FindStation(name);
                        Route route = administration.FindRoute(routeNr);

                        if (check != null && route != null)
                        {
                            route.Stations.Add(check); //add station to route
                            updateListViewRoutes();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong. Could not add station");
                    }
                }
            }
        }

        #endregion

        #region Remove Buttons

        private void btnRemoveWagons_Click(object sender, EventArgs e)
        {
            int wagonNumber;
            if (lstViewWagons.SelectedItems.Count == 1)
            {
                if (int.TryParse(lstViewWagons.SelectedItems[0].SubItems[0].Text, out wagonNumber))
                {
                    Wagon remove = administration.FindWagon(wagonNumber);

                    if (remove != null)
                    {
                        administration.Remove(remove);
                        lstViewWagons.SelectedItems[0].Remove();

                        foreach (Train t in administration.Trains)
                        {
                            t.Wagons.Remove(remove); //remove wagons
                            remove.RemoveWagonFromTrain();
                        }
                   
                        updateListViewTrains();
                    }
                    else
                    {
                        MessageBox.Show("Could not find wagon");
                    }
                }
            }
            else
            {
                MessageBox.Show("Select a wagon to remove");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e) //remove wagon from train
        {
            int wagonNumber;
            int trainUnit;
            if (!int.TryParse(cmboBoxWagons.Text, out wagonNumber))
            {
                MessageBox.Show("Invalid input. Please only enter numbers");
            }
            else
            {
                if (lstViewTrains.SelectedItems.Count != 1)
                {
                    MessageBox.Show("Please select a train");
                }
                else
                {
                    if (int.TryParse(lstViewTrains.SelectedItems[0].SubItems[0].Text, out trainUnit))
                    {
                        Train findTrain = administration.FindTrain(trainUnit);
                        Wagon findWagon = administration.FindWagon(wagonNumber);

                        if (findTrain != null && findWagon != null)
                        {
                            if (findTrain.Wagons.Remove(findWagon))
                            {
                                findWagon.RemoveWagonFromTrain(); //remove wagon from train
                                updateListViewTrains();
                            }
                            else
                            {
                                MessageBox.Show("Selected train doesn't have that wagon");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Could not find wagon.");
                        }
                    }
                }
            }
        }

        private void btnRemoveRoute_Click(object sender, EventArgs e)
        {
            int routeNumber;
            if (!int.TryParse(txtBoxRouteNr.Text, out routeNumber))
            {
                MessageBox.Show("Invalid input. Please only enter numbers");
            }
            else
            {
                Route check = administration.FindRoute(routeNumber);
                if (check == null)
                {
                    MessageBox.Show("Could not find route");
                }
                else
                {
                    foreach (Train t in administration.Trains)
                    {
                        if (t.RouteNr == routeNumber)
                        {
                            t.RouteNr = 0;
                        }
                    }
                    if (administration.Remove(check)) //remove route
                    {
                        updateListViewRoutes();
                        updateListViewTrains();
                    }
                }
            }
        }

        private void btnRemoveRouteNr_Click(object sender, EventArgs e)
        {
            int routeNumber;
            string comboBoxText = cmboBoxRoutes.Text;
            string[] splitComboBoxText = comboBoxText.Split(new string[] { "-" }, StringSplitOptions.None);
            string route = splitComboBoxText[0]; //get only the route Nr
            int.TryParse(route, out routeNumber);

            foreach (Train t in administration.Trains)
            {
                if (t.RouteNr == routeNumber)
                {
                    t.RouteNr = 0;
                }
            }
            updateListViewTrains();
        }

        #endregion

        #region Update Methods

        public void updateListViewTrains()
        {
            administration.Trains.Sort(); //sort list with icomparable interface
            lstViewTrains.Items.Clear(); //delete all items
            string allWagons = "";
            ListViewItem item;
            foreach (Train t in administration.Trains)
            {
                item = new ListViewItem(Convert.ToString(t.TrainUnit)); //make new listview item with trainnumber
                if (t.Wagons != null)
                {
                    allWagons += t.ToString();
                    item.SubItems.Add(allWagons); //column wagons
                    item.SubItems.Add(t.TotalSeats.ToString()); //column total seats
                    item.SubItems.Add(t.TotalStandingSpots.ToString()); // column total standing spots
                }
                if (t.RouteNr > 0) //if there is a route
                {
                    item.SubItems.Add(Convert.ToString(t.RouteNr)); //column with route number
                }
                else
                {
                    item.SubItems.Add("None"); 
                }
                allWagons = ""; //make string clear, because its foreach loop
                lstViewTrains.Items.Add(item); //add all items to listview
            }
        }

        public void updateListViewRoutes()
        {
            administration.Routes.Sort(); //sort routes
            cmboBoxRoutes.Items.Clear(); //delete items comboboxes 
            lstViewRoutes.Items.Clear(); //delete items listview
            string allStations = "";
            ListViewItem item;
            foreach (Route r in administration.Routes)
            {
                item = new ListViewItem(Convert.ToString(r.RouteNr));
                if (r.Stations != null)
                {
                    allStations += r.ToString();
                    item.SubItems.Add(allStations); //in listview all stations
                    string[] allStationsArray = allStations.Split(new string[] { "," }, StringSplitOptions.None);
                    string firstAndLastStation = "Begin: " + allStationsArray.First() + " - Destination: " + allStationsArray.Last();
                    cmboBoxRoutes.Items.Add(r.RouteNr + " - " + firstAndLastStation); //only begin and destination station for comboboxes
                    allStations = "";
                }
                lstViewRoutes.Items.Add(item);
            }
        }

        public void updateListViewWagons()
        {
            administration.Wagons.Sort(); //sort wagons with iComparable interface
            lstViewWagons.Items.Clear(); //delete items in listview
            cmboBoxWagons.Items.Clear(); //delete items in combobox
            ListViewItem item;
            foreach (Wagon w in administration.Wagons)
            {
                item = new ListViewItem(Convert.ToString(w.WagonNumber));
                item.SubItems.Add(Convert.ToString(w.Seats));
                item.SubItems.Add(Convert.ToString(w.StandingSpots));
                lstViewWagons.Items.Add(item); //add wagon to listview
                cmboBoxWagons.Items.Add(w.WagonNumber); //add wagon to combobox
            }
        }

        public void updateStationListBox() //update station list box
        {
            administration.Stations.Sort(); //sort items with IComparable interface
            lstBoxStations.Items.Clear(); //delete items in listbox
            cmboBoxStations.Items.Clear(); //delete items in combobox
            foreach (Station s in administration.Stations)
            {
                lstBoxStations.Items.Add(s.StationName); //print all stations in listview
                cmboBoxStations.Items.Add(s.StationName); //print all stations in combobox
            }
        }

        #endregion

        public bool WagonInUse(Wagon wagon) //check if wagon is in use
        {
            foreach (Train t in administration.Trains)
            {
                foreach (Wagon w in t.Wagons)
                {
                    if (wagon.WagonNumber == w.WagonNumber)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
