   M S B A M L   `   `   `  ����F  BProject_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Project_WPF.ViewsProject_WPF.Views  5   	   '    !Project_WPF.Views.DuiklocatieView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Project_WPF.Views     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��16(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$% Duiklocaties - JP Duik Locaties��5   	   $	��450��61   $	��700��6>   .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      $	��250 �6   �� 5      $	��250 �6   �� 5      $	��200 �6   .+�5   
   �� -   5         ��Name$ 	txtZoeken��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Zoeken op Naam��6W    % !MaterialDesignFloatingHintTextBox#��[ 5      $��0��6M   $��0��6Z   $��2��6j   $
��auto��6~   $��475px��6�   ��5   %   �� *Naam+ �� ValidatesOnDataErrors . 5   �   �� 5   
   $��Zoeken��6   $��0��6#   $��2��60   $��Center=�6@   $��Center=�6]   $	��130��6x   $��Zoeken��6�   ���#6abf69���#6abf69+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��6�   ��6�   �� 6�   �� 5    
   $��0��60   $��2��6@   $��1��6T   $��25��6a   
���  ����6   �� *Foutmelding+6m   &   System.Windows.Controls.DataGrid  5!   
   -   5        	  Name$	 datagridOrderlijnen��5!      
   AutoGenerateColumns
 .  $��2��6L   $��0��6Y   $��3��6i   $
��Left=�6}   $	��275��6�      
IsReadOnly . $��10q�5#   =   $	��670��6J   ��5"      �� *	Locations+ �� SelectedItem 5#      �� *SelectedLocation+   Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn   Header$
 Naam��6>      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Naam+   ElementStyle 5&      �� 5'      .�5(      ��  �� Property � �� �� Value$
 Wrap=�6G   5)      5+        5,      $ Locatie��6>   $
 auto 6O    6%   �� *Stad+6^     5-      $ 	Categorie��6G   $
 auto 6Z    6%   �� *Category.Naam+6i     5.      $ Beschrijving��6U   $	 300 6k    6%   �� *Preview.PreviewBeschrijving+ 5/      �� 50      .�51      ��  � ��$
 Wrap=�6G   52      54        55      $ Prijs��6?   $
 auto 6N    6%   �� *Prijs+6]   57      �� 58   
   $��Terug naar dashboard��6   $��3��61   $��2��6>   $��Center=�6N   $��Center=�6k   $
��auto��6�   $��TerugNaarDashboard��6�   ���#6abf69���#6abf69$ 10��6�   ��6�   �� 6�   �� 59   
   $��Bekijken��6   $��3��6%   $��1��62   $��Center=�6B   $��Center=�6_   $
��auto��6z   $��DuiklocatieBekijken��6�   ���#6abf69���#6abf69$ 10��6�   ��6�   �� 6�   �� 5:   
   $��Toevoegen/Wijzigen��6   $��3��6/   $��0��6<   $��Center=�6L   $��Center=�6i   $
��auto��6�   $$��DuiklocatieWijzigenOfToevoegen��6�   ���#6abf69���#6abf69$ 10��6  ��6�   �� 6  5;      5<      