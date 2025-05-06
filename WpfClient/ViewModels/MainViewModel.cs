using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfClient.Models;
using WpfClient.Services;

namespace WpfClient.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IGrpcListener _grpcListener; // Reference to the injected gRPC listener service

        // A Collection to hold the filtered messages and is bound to the UI (e.g., DataGrid/ListBox)
        // I've used ObservableCollection to ensure that any changes to the list (add/remove) automatically update the UI.
        public ObservableCollection<InformationMessageModel> Messages { get; } = new();

        [RelayCommand]
        public async Task StartListening()
        {
            // Begin listening for gRPC messages. Filtered messages will be added via the MediatR handler.
            await _grpcListener.StartAsync(); 
        }

        // Constructor receives the gRPC listener through dependency injection
        public MainViewModel(IGrpcListener grpcListener)
        {
            _grpcListener = grpcListener;
        }
    }


}
