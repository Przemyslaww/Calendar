   M S B A M L   `   `   `  ����C  ?Calendar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CalendarCalendar  5   	       Calendar.DayWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Calendar     5   	     � Title$   ��5   	   $	��420��5	   	   $	��420��5
   	    � WindowStyle$ 
ToolWindow=�5   	   .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    � MappingMode$ RelativeToBoundingBox=�63    �� 
StartPoint$ 0.5,0&�6W   .��5      �  � Color$ 	#FFA22D98��6    � Offset$ 3Q�61   � 5      $ #121212��6   5       � ColumnDefinitions 5   
   �� 5      $��10 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��10 �6    � RowDefinitions 5   
   �� 5      $��5 �6   �� 5      $��* �6   �� 5      $��8* �6   �� 5      $��* �6   �� 5      $��5 �6   .+�5"   
   �� -   5        $��dayLabel��5#      $��1��5$      $��2��5%      $��Center=�5&      $��Center=�5'      
������ ���#ffdcfd$��20(�5*      $��Italic$�5+      .��6    Dzień5,      �� 5-   
   $��2��5.      $��3��5/      $��1��50      $
��Auto=�51      .��52      �� -   5        	 ��Name$	 toDoList��53      $��Stretch=�54      $
��auto��55      $	��Top=�56      $
��auto��57      59      5:      �� 5;   
   -   5        
 ��Name$
 enteredText��5?      $��3��5<      $��1��5=      $��2��5>      $��Center=�5@      $��Center=�5A      $��Center=�5B      $��25��5C      $��15(�5D      
������ 
�������
�������$��2q�5H      �� 5I   
   -   5        $��3��5J      $��3��5K      $��80��5L      $��25��5M       �� 	IsDefault . $��Center=�5P      $��Center=�5Q      
�������$��2q�5S      
������ 
�������.��5U       Dodaj5V      5W      5X      