   M S B A M L   `   `   `  ����@  <WPF_A, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPF_AWPF_A  5   	   clr-namespace:WPF_AWPF_A  5   	       WPF_A.GameClient   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:WPF_A     5   	   #srcclr-namespace:WPF_A     5   	     � Title$  Cards Game Client��5	   	    � WindowState$ 	Maximized=�6#    � DataContext 5
         WPF_A.GameViewModel  5   
    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ ApplicationCommands.Close��5      5   (     5   
   -   5        $ ApplicationCommands.Save��5      5   (     5   
   -   5        $* $local:GameViewModel.StartGameCommand��5      5   0     5   
   -   5        $* $local:GameViewModel.ShowAboutCommand��5      5   0     5   
   -   5        $&  local:GameOptions.OptionsCommand��5      5   0   .��5      � ���	#FFE22525 � RowDefinitions 5   
   �� 5      $��58 �6   �� 5      $��20 �6   �� 5      �� 5      $��42 �6   .+�5    
   �� $��0��6   ���#C40D42.+�5!      �� $��56��6    �� Left$ 0��6    
 �� Top$ 0��60   $��UniformToFill=�6?   $��.\BackgroundTile.png��6W   �� 5"       �� Right$ 10��6   $ 13��6&   $��New Game��66   ���	#FFF7EFEF$��Times New Roman)�6`   $��24(�6}   $
��Bold"�6�   5#      ]� 5$   
   $��0q�6   $��1��6    .+�5%      o� 
���   �$
��Bold"�6&   
�������.@�5&      m� $��_File��6   .@�5'      m� $��_New Game...��6   
���   �$	��200��6H   	 m� Command$*	 $local:GameViewModel.StartGameCommand��5(      m� 5)      $��_Open��6   $	��200��6.   
���   �6:   m� 5*      $��_Save��6   $	��200��6.   
���   �$
	 Save��6M   
 m� Icon
 5+      �� 5,      $��.\base_floppydisk_32.png��6$   $��20��6F   5.      �� 5/      $	��145��6    
���   �6,   m� 50      $��_Close��6   $	��200��6/   
���   �$	 Close��6N   51      m� 52      $��_Game��6   
���   �
�������.@�53      m� $��_Undo��6   $
��Left=�6.   $	��145��54      
���   �6   55      m� 56      $��_Tools��6   
���   �
�������.@�57      m� $��_Options��6   $
��Left=�61   $	��200��6L   
���   �$&	  local:GameOptions.OptionsCommand��58      59      m� 5:      $
��Help��6   
���   �
�������.@�5;      m� $��_About��6   $
��Left=�6/   $	��145��6J   
���   �$*	 $local:GameViewModel.ShowAboutCommand��5<      5=      5>      5?      ]� 5@   
   $��2��6   .+�5A         WPF_A.CardsInHandControl  -   5          Name$ Player2Hand��5A   '   $��Right=�6<   $	��380��5B      $��Center=�5C      $	��180��6&      PlayerOrientation$ Vertical=�62      Game 5B      ��    Owner 5D      �� *
Players[1]+   PlayerState 6(   �� *Players[1].State+  5E      -   5        $ Player4Hand��5E   '   $
��Left=�6<   $
��Left=�5F      $	��380��6&   $��Center=�63   $ Vertical=�5G      $	��180��6E    6(   �� *
Players[3]+ 5H      �� *Players[3].State+ 64   ��   5I      -   5        $ Player1Hand��5I   '   $	��Top=�6<   $��Center=�5J      $	��154��6(   $	��Top=�65   $ 
Horizontal=�5K      $	��380��6G    6*   �� *
Players[0]+ 5L      �� *Players[0].State+ 64   ��   5M      -	   5        $ Player3Hand��5M   '   $��Bottom=�6<   $��Center=�5N      $	��154��6(   $	��Top=�65   $ 
Horizontal=�5O      $	��380��6G    6*   �� *
Players[2]+ 5P      �� *Players[2].State+ 64   ��    WPF_A.GameDecksControl  5Q      -
   5          Name$ 	GameDecks��5Q   2   $	��180��6%      Deck 6E   �� *
GameDeck+   AvailableCard 5R      �� *CurrentAvailableCard+   CurrentPlayer 5S      �� *CurrentPlayer+   GameStarted 5T      �� *GameStarted+5U      �� 5V   
   $��3��6   $
��Left=�6!   $��0,0,0,15q�6<   $��Center=�5W      
���   �
�������$
��Bold"�6U   .@�5X      �� $��Center=�6   .��5Y      �� ��6   �� *CurrentStatusText+5Z      5[      5\      5]      