﻿using Clean_Reader.Controls.Components;
using Clean_Reader.Controls.Layout;
using Clean_Reader.Models.UI;
using Lib.Share.Models;
using Richasy.Controls.Reader;
using Richasy.Controls.Reader.Models;
using Richasy.Controls.UWP.Popups;
using Richasy.Font.UWP;
using Richasy.Helper.UWP;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Yuenov.SDK;
using Yuenov.SDK.Models.Discovery;
using Yuenov.SDK.Models.Share;

namespace Clean_Reader.Models.Core
{
    public partial class AppViewModel
    {
        public double _narrowBreakpoint = 1000;

        private WaitingPopup _waitPopup;
        public YuenovClient _yuenovClient;
        private DispatcherTimer _checkFileTimer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(5) };

        public ReaderPanel _reader;
        public SidePanel _sidePanel;
        public NavigateMenu _menu;
        public Frame _rootFrame;

        private const string _clientId = "4ce94634-4e8d-4e7a-9967-18c59afd1dc7";
        private string[] _scopes = new string[] { "Files.ReadWrite.AppFolder", "User.Read" };
        public OneDriveHelper _onedrive;

        private bool _isHistoryChanged;
        public bool IsHistoryChanged
        {
            get => _isHistoryChanged;
            set
            {
                _isHistoryChanged = value;
                if (value)
                    ProgressChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private bool _isStyleChanged = false;
        public bool IsDetailChanged = false;

        public List<Lib.Share.Models.Book> TotalBookList = new List<Lib.Share.Models.Book>();

        public ObservableCollection<Shelf> ShelfCollection = new ObservableCollection<Shelf>();

        private Shelf _currentShelf;
        public Shelf CurrentShelf
        {
            get => _currentShelf;
            set
            {
                if (_currentShelf == null || !_currentShelf.Equals(value))
                {
                    _currentShelf = value;
                    CurrentShelfChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public Lib.Share.Models.Book CurrentBook;

        public ObservableCollection<Lib.Share.Models.Book> DisplayBookCollection = new ObservableCollection<Lib.Share.Models.Book>();
        public ObservableCollection<Lib.Share.Models.Book> LastestReadCollection = new ObservableCollection<Lib.Share.Models.Book>();
        public List<ReadHistory> HistoryList = new List<ReadHistory>();

        public ObservableCollection<SystemFont> FontCollection = new ObservableCollection<SystemFont>();
        public ObservableCollection<ReaderColorConfig> ColorConfigCollection = new ObservableCollection<ReaderColorConfig>();

        public ObservableCollection<Category> CategoryCollection = new ObservableCollection<Category>();
        public ObservableCollection<DiscoveryContainer> DiscoveryCollection = new ObservableCollection<DiscoveryContainer>();
        public ObservableCollection<SpecialContainer> TopicCollection = new ObservableCollection<SpecialContainer>();
        public ObservableCollection<Rank> RankCollection = new ObservableCollection<Rank>();
        public ReaderStyle ReaderStyle;

        public List<Tuple<Type, object>> SubFrameHistoryList { get; set; } = new List<Tuple<Type, object>>();

        public List<Richasy.Controls.Reader.Models.Chapter> CurrentBookChapterList = new List<Richasy.Controls.Reader.Models.Chapter>();
        public List<Richasy.Controls.Reader.Models.ChapterDetail> CurrentBookChapterDetailList = new List<Richasy.Controls.Reader.Models.ChapterDetail>();

        public event EventHandler CurrentShelfChanged;
        public event EventHandler ProgressChanged;
    }
}
