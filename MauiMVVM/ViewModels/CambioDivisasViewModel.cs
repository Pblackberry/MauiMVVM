using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace MauiMVVM.ViewModels
{
    internal class CambioDivisasViewModel : INotifyPropertyChanged
    {
        private string _valorDolares;
        private string _valorEuros;
        public string ValorDolares
        {
            get => _valorDolares;
             set
            {
                if (_valorDolares != value)
                {
                    _valorDolares = value;
                    OnPropertyChanged();
                    ConvertirDolaresAEuros();
                    //generar eventos para cambiar de dolares a euros
                }
            }
        }
        public string ValorEuros
        {
            get => _valorEuros;
            private set 
            { 
                if (_valorEuros != value)
                {
                   _valorEuros = value;
                    OnPropertyChanged();
                    //ConvertirEurosADolares();
                }
            }
        }

        public void ConvertirDolaresAEuros()
        {
            double conversion=Double.Parse(_valorDolares)*0.95;
            ValorEuros=$"{conversion:F2}";
        }

        public void ConvertirEurosADolares()
        {
           // ValorDolares = ValorEuros * 1.05;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name=" ")=>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
