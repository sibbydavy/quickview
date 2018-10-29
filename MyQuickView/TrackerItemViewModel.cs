using System;
using System.Configuration;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuickAccess
{
    public class TrackerItemViewModel : ViewModelBase
    {
        #region Commands

        public ICommand TopTrackerItemCommand
        {
            get
            {
                return new RelayCommand(OnTopTrackerItemClick);
            }
        }

        public ICommand DownTrackerItemCommand
        {
            get
            {
                return new RelayCommand(OnDownTrackerItemClick);
            }
        }

        public ICommand RighthTrackerItemCommand
        {
            get
            {
                return new RelayCommand(OnRighthTrackerItemClick);
            }
        }

        public ICommand LeftTrackerItemCommand
        {
            get
            {
                return new RelayCommand(OnLeftTrackerItemClick);
            }
        }

        #endregion

        void CallAction(string actionName)
        {
            try
            {
                Task.Factory.StartNew(() => {
                    try
                    {
                        if (actionName.Contains(".exe"))
                        {
                            ProcessStartInfo pi = new ProcessStartInfo();
                            pi.Verb = "runas";
                            pi.FileName = actionName;
                            Process.Start(pi);
                        }
                        else
                        {
                            Process.Start(actionName);
                        }

                    }
                    catch (Exception ex)
                    {

                    }

                });


            }
            catch (Exception)
            {

            }

        }

        internal void OnTopTrackerItemClick()
        {
            CallAction(ConfigurationManager.AppSettings["topImageAction"]);
        }

        internal void OnRighthTrackerItemClick()
        {
            CallAction(ConfigurationManager.AppSettings["rightImageAction"]);
        }

        internal void OnLeftTrackerItemClick()
        {
            CallAction(ConfigurationManager.AppSettings["leftImageAction"]);
        }

        internal void OnDownTrackerItemClick()
        {
            CallAction(ConfigurationManager.AppSettings["bottomImageAction"]);
        }


        internal void OnProjectItemClick(string value)
        {
            Process.Start(value);
        }
    }
}
