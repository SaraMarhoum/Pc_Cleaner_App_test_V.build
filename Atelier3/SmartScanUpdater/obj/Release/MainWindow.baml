   M S B A M L   `   `   `  ���� K  GSmartScanUpdater, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:SmartScanUpdaterSmartScanUpdater  !    SmartScanUpdater.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:SmartScanUpdater       � Title$  
MainWindow��$��310.31��$	��800�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�.��� ����  �� ImageSource$ background6.jpg��.+��� -    ��Name$ img_logo��$	��133��$	��Top=�$��0,23,-0.4,0q�$��logo.png��� -    �Name$ bar_progress��$��142,183,142.6,74.6q�$y�Hidden=�����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&� �� Opacity$
 0.75Q�	 �� RelativeTransform	 V� .~��� 
 �� CenterY$	
 0.5Q� �� CenterX$	 0.5Q���  �� CenterY$	 0.5Q� �� CenterX$	 0.5Q���  �� Angle$ 261.741Q� �� CenterY$	 0.5Q� �� CenterX$	 0.5Q�T� .���  � Color$ Black�� � Offset$ 0Q�� $ 	#FFB565EB��$ 1Q��� -    ��Name$ 	btn_start��$��Commener la mise à jour��$	��237��$��42��$��Center=�$��Center=�
�������$
��Bold"�$��18(�$��284,183,272.6,56.6q����� $ 0.5,1&�$ 0.5,0&�$
 0.75Q�	 V� .~��� $	
 0.5Q�$	 0.5Q��� $	 0.5Q�$	 0.5Q��� $ 220.601Q�$	 0.5Q�$	 0.5Q�T� .��� $ Black��$ 0Q�� $ 	#FF6E40AE��$ 1Q��� -   $ 
btn_quiter��$��Finir��$	��151��$��42��$��Bottom=�$��Right=�$��0,0,20.6,9.6q�
�������$
��Bold"�$��18(�$y�Hidden=����� $ 0.5,1&�$ 0.5,0&�$
 0.75Q�	 V� .~��� $	
 0.5Q�$	 0.5Q��� $	 0.5Q�$	 0.5Q��� $ 220.601Q�$	 0.5Q�$	 0.5Q�T� .��� $ Black��$ 0Q�� $ 	#FF6E40AE��$ 1Q��� -    ��Name$ 
txt_status��$��Mis à jour en cours...��$
��Bold"�
�������$��35��$��20(�$��Center=�$��231,234,231.6,12.6q� �� TextAlignment$ Center=�$
��Wrap=�$y�Hidden=�