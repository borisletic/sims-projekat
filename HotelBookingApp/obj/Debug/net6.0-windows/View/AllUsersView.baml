   M S B A M L   `   `   `  ����J  FHotelBookingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:HotelBookingApp.ViewHotelBookingApp.View  5   	   '    !HotelBookingApp.View.AllUsersView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:HotelBookingApp.View     5   	     � Title$  Users��5   	   $	��500��6   $	��850��6$   .��5	      � .+�5
   
   ]� .+�5      � $	��Top=�6   $��80��6-   .+�5      �� -   5         ��Name$ 	myTextBox��5      $��	20,20,0,0q�6.   $��22��6�   $	��130��6�   ��6A   �� *
UserType+ �� SelectedItem 6b   �� *SelectedUser+6�   �� 5      -   5        $��8,20,0,0q�5   -   $��Search��6?   $��22��6P   $��50��6\   �� 5      -   5        $��8,20,0,0q�5   ,   $��Clear��6>   $��22��6N   $��50��6Z   �� 5      -   5        $��22��5   ,   $��
Name (A-Z)��68   $��	48,20,0,0q�6M   �� 5      -   5        $��22��5   /   $��Surname (A-Z)��6;   $��8,20,0,0q�6S   �� 5      -   5        $��
138,20,0,0q�5      $��Create Owner��6F   $��22��6]   �� 5      -   5        $��8,20,0,0q�5      $��Hotels��6?   $��22��6P   $��50��6]   �� 5      -   5        $��8,20,0,0q�5      $��22��69   .��6E   Block6L   �� 5      -	   5        $��	733,5,0,0q�5      $��22��6<   .��6H   	Unblock6Q   �� 5      -
   5        $��
Name (Z-A)��5   4   $��22��6I   $��315,-20,50,0q�6U   �� 5      -   5        $��Surname (Z-A)��5   7   $��22��6O   $��389,-22,50,0q�6[   5       &   System.Windows.Controls.DataGrid  5#      -   5          Name$ 
MyDataGrid��5'      $��Bottom=�5#         AutoGenerateColumns$ False��5%         
IsReadOnly$
 True��63   $	��740��5&      $	��314��6#   ��5$      ��  �� Path$ Users� �� UpdateSourceTrigger$ PropertyChanged=� 5%   E   �� *
ChosenUser+   Columns 5)      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn	   Header$
	 JMBG��6*   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 120 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *Jmbg+6_     5-      $	 Email��6*   $	
 120 6S    69   �� *Email+6a     5.      $
	 Name��6*   $	
 120 6Q    68   �� *Name+6_     5/      $	 Surname��6*   $	
 120 6W    6;   �� *	Surname+6e     50      $	 Phone number��6*   $	
 120 6`    6@   �� *PhoneNumber+6n     51      $	 Blocked��6*   $	
 110 6W    6;   �� *	Blocked+6e   55      57      59      5:      