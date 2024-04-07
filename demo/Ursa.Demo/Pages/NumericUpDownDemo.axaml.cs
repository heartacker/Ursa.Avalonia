using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using System.Diagnostics;
using VariableBox.Controls;
using VariableBox.Demo.ViewModels;

namespace VariableBox.Demo.Pages;

public partial class NumericUpDownDemo : UserControl
{
    NumericUpDownDemoViewModel vm;
    public NumericUpDownDemo()
    {
        InitializeComponent();
        DataContext = vm = new NumericUpDownDemoViewModel();
        numd.ValueChanged += Numd_ValueChanged;
        numd.ReadRequested += Numd_ReadRequested;
    }

    Random random = new Random();
    private void Numd_ReadRequested(object? sender, RoutedEventArgs e)
    {
        Trace.WriteLine(e.Source);
        Trace.WriteLine(sender as VariableBoxUInt);
        var val = (sender as VariableBoxUInt).Value;
        var a = (uint)random.Next(0, 100);
        vm.ReadRequestedUpdateText = $"ReadRequested,Old={val} => {a}";
        vm.Value = a;
    }


    int i = 0;
    private void Numd_ValueChanged(object? sender, ValueChangedEventArgs<uint> e)
    {
        vm.ValueChangedUpdateText = $"ValueChanged_{i++},Old={e.OldValue} => {e.NewValue}";
    }
}