   M S B A M L   `   `   `  ����@  <WPF_A, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPF_AWPF_A  5   	       WPF_A.Options   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:WPF_A     5   	     � Title$  Options��5   	   $	��345��6   $	��434��6&    � 
ResizeMode$ NoResize=�62   .��5	      �  � RowDefinitions 5
   
   �� 5      $��58 �6   �� 5      $��20 �6   �� 5      �� 5      $��42 �6   .+�5   
   �� $��0��6   ���#C40D42.+�5      �� -   5         ��Name$ image��5      $��56��6#    �� Left$ 0��6/   
 �� Top$ 0��6?   $��UniformToFill=�6N   $��.\BackgroundTile.png��6f   �� 5      -   5         ��Name$ label��5      $��Options��6#    �� Right$ 10��65   $ 13��6G   $��Times New Roman)�6X   ���	#FFF7EFEF$��24(�6�   $
��Bold"�6�   5      �� 5   
   $��1��6   
���   � � 	Resources 5         WPF_A.NumberOfPlayers   numberOfPlayersData��%   &	          5      6(   5      .+�5      �� -   5        	 ��Name$	 
tabControl��5      $��1��6-   $	��208��6:   $ 10��6G   $ 2��6X   $	��408��6g   .@�5      �� $
��Game��6   .��5      � ���	#FFE5E5E5.+�5      �� -   5        
 ��Name$
 checkBox��5   #   $��Number of players��65   $
��Left=�6Q   $��	10,54,0,0q�6l   $	��Top=�6    d� 	IsChecked 6�   ��  �� Path$ PlayAgainstComputer��� 5      -   5        $��numberOfPlayersComboBox��5   u   $
��Left=�6#   $��
196,58,0,0q�6>   $	��Top=�6R   $��86��6j   {�6�   ��  �� ElementName$ playAgainstComputerCheck��$ 	Ischecked���6�   ��  �� Source# [   �� SelectedValue 6"  �� $ NumberOfPlayers�5      5      �� 5      $��Computer Player��6   .��5       � ���	#FFE5E5E5.+�5!      �� -   5        $ label1��5!       $��Skill Level��60   $
��Left=�6F   $��	10,10,0,0q�6a   $	��Top=�6t   	� 5"      -   5         	�Name$ dumbAIRadioButton��5"   &   $
��Dumb��6A   $
��Left=�6P   $��	37,41,0,0q�6k   $	��Top=�6~   $
 TrueY�6�   6�   	� 5#      -   5        $ goodAIRadionButton��5#   &   $
��Good��6B   $
��Left=�6Q   $��	37,62,0,0q�6l   $	��Top=�6   6�   	� 5$      -	   5        $ cheatingAIRadionButton��5$   &   $��Cheats��6F   $
��Left=�6W   $��	37,83,0,0q�6r   $	��Top=�6�   6�   5%      5&      5'      5)      �� 5*   
   $��3��6    �� Orientation$ 
Horizontal=�6#   $��RightToLeft=�6<   .+�5+      �� -
   5         ��Name$ cancelButton��5+      $��_Cancel��6+   $��22��6=   $��75��6J   $��10,0,0,0q�6U   6g   �� 5,      -   5        $ okButton��5,      $	��_OK��6'   $��75��65   $��22��6@   $��10,0,0,0q�6L   6^   5-      5/      50      