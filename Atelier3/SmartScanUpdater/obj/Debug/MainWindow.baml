   M S B A M L   `   `   `  ����K  GSmartScanUpdater, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:SmartScanUpdaterSmartScanUpdater  5   	   !    SmartScanUpdater.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:SmartScanUpdater     5   	     � Title$  
MainWindow��5   	   $��310.31��6   $	��800��6,    � 
ResizeMode$ NoResize=�68    � WindowStartupLocation$ CenterScreen=�6N   .��5	      � ��5   
   �� 5       �� ImageSource$ background6.jpg��6   .+�5   
   �� -   5         ��Name$ img_logo��5      $	��133��6"   $	��Top=�61   $��0,23,-0.4,0q�6I   $��logo.png��6^   � 5   
   -   5         �Name$ bar_progress��5      $��142,183,142.6,74.6q�6,   $y�Hidden=�6H   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67    �� Opacity$
 0.75Q�6J   	 �� RelativeTransform	 5      V� 5      .~�5      �� 
 �� CenterY$	
 0.5Q�6-    �� CenterX$	 0.5Q�6;   �� 5       �� CenterY$	 0.5Q�6,    �� CenterX$	 0.5Q�6:   �� 5       �� Angle$ 261.741Q�6.    �� CenterY$	 0.5Q�6>    �� CenterX$	 0.5Q�6L   T� 5      5      .��5      �  � Color$ Black��6#    � Offset$ 0Q�61   � 5      $ 	#FFB565EB��6#   $ 1Q�65   5      5       �� 5"   
   -   5         ��Name$ 	btn_start��5"      $��Commener la mise à jour��6%   $	��237��6H   $��42��6T   $��Center=�6`   $��Center=�6{   
�������$
��Bold"�6�   $��18(�6�   $��284,183,272.6,56.6q�6�   ��5#      �� 5$      $ 0.5,1&�6&   $ 0.5,0&�67   $
 0.75Q�6J   	 5%      V� 5&      .~�5'      �� $	
 0.5Q�6-   $	 0.5Q�6;   �� 5(      $	 0.5Q�6,   $	 0.5Q�6:   �� 5)      $ 220.601Q�6.   $	 0.5Q�6>   $	 0.5Q�6L   T� 5*      5+      .��5-      � $ Black��6#   $ 0Q�61   � 5.      $ 	#FF6E40AE��6#   $ 1Q�65   5/      51      �� 53   
   -   5        $ 
btn_quiter��53      $��Finir��6&   $	��151��67   $��42��6C   $��Bottom=�6O   $��Right=�6j   $��0,0,20.6,9.6q�6�   
�������$
��Bold"�6�   $��18(�6�   $y�Hidden=�6�   ��54      �� 55      $ 0.5,1&�6&   $ 0.5,0&�67   $
 0.75Q�6J   	 56      V� 57      .~�58      �� $	
 0.5Q�6-   $	 0.5Q�6;   �� 59      $	 0.5Q�6,   $	 0.5Q�6:   �� 5:      $ 220.601Q�6.   $	 0.5Q�6>   $	 0.5Q�6L   T� 5;      5<      .��5>      � $ Black��6#   $ 0Q�61   � 5?      $ 	#FF6E40AE��6#   $ 1Q�65   5@      5B      �� 5D   
   -   5         ��Name$ 
txt_status��5D      $��Mis à jour en cours...��6(   $
��Bold"�6F   
�������$��35��6k   $��20(�6w   $��Center=�6�   $��231,234,231.6,12.6q�6�    �� TextAlignment$ Center=�6�   $
��Wrap=�6�   $y�Hidden=�6�   5G      5H      