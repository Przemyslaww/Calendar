   M S B A M L   `   `   `  ����C  ?Calendar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CalendarCalendar  5          Calendar.TaskControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:Calendar     5      $��Stretch=�5      $��Stretch=�5	      $��Stretch=�5
      $��Stretch=�5      $
��auto��5      $
��auto��5      $��2 0 2 4q�5      .��5      ��   �� CornerRadius$  8��6    �� Padding$ 5q�6   
������ ���	#2fBA68C8$��0q�6]    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ #BA68C8��6      
BlurRadius$ 10Q�6/      	Direction$	 -90Q�6?      RenderingBias$ Quality=�6O      ShadowDepth$ 3Q�6g   ._�5   
   � -   5         �Name$ 	gridTasks��5      $��30��5      $��Center=�5      	 � ColumnDefinitions	 5      �� 5      -   5        
 �Name$

 col1��5   -   $��* �6#   6-   �� 5      -   5        $

 col2��5   .   $��6* �6#   6.   �� 5      -   5        $

 col3��5   -   $��* �6#   6-    � RowDefinitions 5      �� 5      -   5        $	
 Row��5       .+�5!      �� -   5         ��Name$ checkBox��5"      $��0��5#      $��Center=�5$      $��Center=�5%      �� 5&      -   5         ��Name$ 	textBlock��5'      $��1��5(      $��Center=�5)      $
��Left=�5*      $��15(�5+      
�������5-      �� 5.      -   5        $��24��5/      $��2��50      
������ 
������ $��Center=�54      $��Center=�55      .��56      �� $
��Fill=�6   $��images/remove.png��6'   $��20��6B   $��20��6N   57      58      5:      5;      