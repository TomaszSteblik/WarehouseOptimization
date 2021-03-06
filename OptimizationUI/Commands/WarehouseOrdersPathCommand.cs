﻿using System;
using System.Windows.Input;
using Microsoft.Win32;
using OptimizationUI.Models;

namespace OptimizationUI.Commands
{
    public class WarehouseOrdersPathCommand : ICommand
    {
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            var fileDialog = new OpenFileDialog
            {
                Filter = "txt files (*.txt)|*.txt", 
                RestoreDirectory = true
            };
            fileDialog.ShowDialog();
            var warehouse = parameter as Warehouse;
            warehouse.OrdersPath = fileDialog.FileName;
        }

        public event EventHandler? CanExecuteChanged;
    }
}