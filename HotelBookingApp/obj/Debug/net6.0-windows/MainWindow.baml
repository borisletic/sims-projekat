   M S B A M L   `   `   `  ����J  FHotelBookingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HotelBookingAppHotelBookingApp  5   	        HotelBookingApp.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:HotelBookingApp     5   	     � Title$  Login��5   	   $	��300��6   $	��300��6$   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��100 �6   6+   �� 5      $	��100 �6   �� 5      $	��100 �6   .+�5   
   �� $��0��6   $��30��6   $��
63,32,0,38q�6)   $
��Left=�6=   $��64��6X   $��Email��6c   �� 5   
   $��1��6   $��30��6   $��
63,32,0,38q�6)   $
��Left=�6=   $��64��6X   $��Password��6c   �� 5   
   -   5         ��Name$ emailBox��5      $��0��6$   $��20��61   $��62,70,62,10q�6=   ��6R   ��  �� Path$ Email��� 5   
   -   5         ��Name$ emailErrorText��5   6   $��2��6   $��60,-10,45,0q�6!   
���  ��$y�	Collapsed=�6_   G� 5   
   -   5         G�Name$ passwordBox��5   8   $��1��6   $��63,70,62,10q�6#   $��20��6M    G� Password$  ��6Y   �� 5   
   -   5        $��2��5      $��Login��6    �� IsCancel$
 True��6.   $��Center=�6>   $��74��6i   $��	0,30,0,40q�6t   5      5      