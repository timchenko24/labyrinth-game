   M S B A M L   `   `   `  ����D  @Labyrinth, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:LabyrinthNSLabyrinthNS  5   	       LabyrinthNS.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:LabyrinthNS     5   	   -   5          �Name$  	Labyrinth��5   	    � Title$ 	Labyrinth��5   	    � WindowStartupLocation$ CenterScreen=�6    � 
ResizeMode$ NoResize=�6@   $��0q�6V    � SizeToContent$ WidthAndHeight=�6a   ��5	      �� 5
   
    �� EndPoint$ 0.5,1&�6    � MappingMode$ RelativeToBoundingBox=�6/    �� 
StartPoint$ 0.5,0&�6S   .��5      �  � Color$ 	#FFA4E6FF��6   	 � Offset$	 0Q�6-   � 5      $ 	#FF4690AC��6   $	 1Q�6-   5      .��5      � .+�5   
   �� -   5        
 ��Name$
 cnvsLabyrinth��5      $��	17,6,17,0q�6(   $��Center=�6;   $	��Top=�6X   $	��400��6p   $	��400��6}   5      �� 5   
   -   5         ��Name$ lblLivesCounter��5      $��Lives:��6)    �� Left$ -1��6:   
 �� Top$	 411��6K   $
��Left=�6\   $��16(�6w   $��Rockwell Extra Bold)�6�   ���	#FFC50000$��17,418,0,50q�6�   �� 5   
   -   5         ��Name$ 	btnMoveUp��5      $	��▲��6$   $
��Left=�60   $	��Top=�6K   $��30��6c   $��193,418,0,0q�6n   $��20��6�   6�   �� 5   
   -   5        $ btnMoveLeft��5      $	��▲��6&   $
��Left=�62   $	��Top=�6M   $��30��6e   $��168,443,0,0q�6p    J� RenderTransformOrigin$ 0.5,0.5&�6�   $��20��6�   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$	 -90Q�6&   T� 5      5      5      �� 5   
   -   5        $ btnMoveDown��5      $	��▲��6&   $
��Left=�62   $	��Top=�6M   $��30��6e   $��193,468,0,0q�6p   $ 0.5,0.5&�6�   $��20��6�   z�5      V� 5       .~�5!      �� �� 5"      �� 5#      $
 -180Q�6&   T� 5$      5%      5'      �� 5(   
   -   5        $ btnMoveRight��5(      $	��▲��6'   $
��Left=�63   $	��Top=�6N   $��30��6f   $��218,443,0,0q�6q   $ 0.5,0.5&�6�   z�5)      V� 5*      .~�5+      �� �� 5,      �� 5-      $ 90Q�6&   T� 5.      5/      51      52      53      