﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPDCtrl.Common;

namespace MPDCtrl.Models
{
    //SongInfo > SongInfoEx
    //Song > SongInfo
    //SongFile

    /// <summary>
    /// Generic song file class. (for listall)
    /// </summary>
    public class SongFile : ViewModelBase
    {
        public string File { get; set; } = "";

    }

    /// <summary>
    /// SongInfo class. (for playlist or search result)
    /// </summary>
    public class SongInfo : SongFile
    {
        public string Title { get; set; } = "";
        public string Track { get; set; } = "";
        public string Disc { get; set; } = "";
        public string Time { get; set; } = "";
        public string TimeFormated
        {
            get
            {
                string _timeFormatted = "";
                try
                {
                    if (!string.IsNullOrEmpty(Time))
                    {
                        int sec, min, hour, s;

                        double dtime = double.Parse(Time);
                        sec = Convert.ToInt32(dtime);

                        //sec = Int32.Parse(_time);
                        min = sec / 60;
                        s = sec % 60;
                        hour = min / 60;
                        min = min % 60;

                        if ((hour == 0) && min == 0)
                        {
                            _timeFormatted = String.Format("{0}", s);
                        }
                        else if ((hour == 0) && (min != 0))
                        {
                            _timeFormatted = String.Format("{0}:{1:00}", min, s);
                        }
                        else if ((hour != 0) && (min != 0))
                        {
                            _timeFormatted = String.Format("{0}:{1:00}:{2:00}", hour, min, s);
                        }
                        else if (hour != 0)
                        {
                            _timeFormatted = String.Format("{0}:{1:00}:{2:00}", hour, min, s);
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("Oops@TimeFormated: " + Time + " : " + hour.ToString() + " " + min.ToString() + " " + s.ToString());
                        }
                    }
                }
                catch (FormatException e)
                {
                    // Ignore.
                    // System.Diagnostics.Debug.WriteLine(e.Message);
                    System.Diagnostics.Debug.WriteLine("Wrong Time format. " + Time + " " + e.Message);
                }

                return _timeFormatted;
            }

        }
        public double TimeSort
        {
            get
            {
                double dtime = double.NaN;
                try
                {
                    dtime = double.Parse(Time);
                }
                catch { }
                return dtime;
            }
        }
        public string Duration { get; set; } = "";
        public string Artist { get; set; } = "";
        public string Album { get; set; } = "";
        public string AlbumArtist { get; set; } = "";
        public string Composer { get; set; } = "";
        public string Date { get; set; } = "";
        public string Genre { get; set; } = "";
        
        private string _lastModified;
        public string LastModified
        {
            get
            {
                return _lastModified;
            }
            set
            {
                if (_lastModified == value)
                    return;

                _lastModified = value;
            }
        }

        public string LastModifiedFormated
        {
            get
            {
                DateTime _lastModifiedDateTime = default(DateTime); //new DateTime(1998,04,30)

                if (!string.IsNullOrEmpty(_lastModified))
                {
                    try
                    {
                        _lastModifiedDateTime = DateTime.Parse(_lastModified, null, System.Globalization.DateTimeStyles.RoundtripKind);
                    }
                    catch
                    {
                        System.Diagnostics.Debug.WriteLine("Wrong LastModified timestamp format. " + _lastModified);
                    }
                }

                var culture = System.Globalization.CultureInfo.CurrentCulture;
                return _lastModifiedDateTime.ToString(culture);
            }
        }

        // for sorting and (playlist pos)
        private int _index;
        public int Index
        {
            get
            {
                return _index;
            }
            set
            {
                if (_index == value)
                    return;

                _index = value;
                this.NotifyPropertyChanged("Index");
            }
        }

        public int IndexPlusOne
        {
            get
            {
                return _index+1;
            }
        }

    }

    /// <summary>
    /// song class with some extra info. (for queue)
    /// </summary>
    public class SongInfoEx : SongInfo
    {
        // Queue specific

        public string Id { get; set; }

        private string _pos;
        public string Pos
        {
            get
            {
                return _pos;
            }
            set
            {
                if (_pos == value)
                    return;

                _pos = value;
                this.NotifyPropertyChanged("Pos");
            }
        }

        private bool _isPlaying;
        public bool IsPlaying
        {
            get
            {
                return _isPlaying;
            }
            set
            {
                if (_isPlaying == value)
                    return;

                _isPlaying = value;
                this.NotifyPropertyChanged("IsPlaying");
            }
        }
    }

}
