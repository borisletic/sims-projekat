   M S B A M L   `   `   `  ����J  FHotelBookingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:HotelBookingApp.ViewHotelBookingApp.View  5   	   1    +HotelBookingApp.View.HotelApprovalTableView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:HotelBookingApp.View     5   	     � Title$  Hotel Approval��5	   	   $	��450��6    $	��800��6-   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
MyDataGrid��5      $��Bottom=�5         AutoGenerateColumns$ False��5         
IsReadOnly$
 True��6/   $	��304��6h   $��96,53,97,50q�6u   ��5      ��  �� Path$ Hotels� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 5   A   �� *SelectedHotel+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Code��6&   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 140 6M   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 64   �� *Code+6[     5      $
 Name��6&   $		 140 6M   
 64   �� *Name+6[     5      $ Construction year��6&   $		 150 6f   
 6A   �� *ConstructionYear+6t     5!      $ Number of stars��6&   $		 150 6_   
 6?   �� *StarsNumber+6m   5%      �� 5(   
   -   5        $��Close��5(   $   $
��Left=�64   $��22��6O   $��
660,24,0,0q�6[   $	��Top=�6o   $��43��6�   5*      5,      