   M S B A M L   `   `   `  ����F  BProject_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Project_WPF.ViewsProject_WPF.Views  5   	   &     Project_WPF.Views.FavorietenView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Project_WPF.Views     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��16(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$# Favorieten - JP Duik Locaties��5   	   $	��400��6/   $	��700��6<   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      $	��250 �6   �� 5      $	��250 �6   �� 5      $	��200 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ datagridOrderlijnen��5         AutoGenerateColumns .  $��0��6L   $��0��6Y   $��3��6i   $
��Left=�6}   $	��275��6�      
IsReadOnly . $��10q�5   E   $	��670��6R   ��5      �� *LocationCustomers+ �� SelectedItem 5      �� *SelectedLocationCustomer+	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn
   Header$

 Naam��6G      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6U   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Location.Naam+   ElementStyle 5!      �� 5"      .�5#      ��  �� Property � �� �� Value$
 Wrap=�6G   5$      5&        5'      $
 Locatie��6G   $
 auto 6X    6%   �� *Location.Stad+6g     5(      $
 	Categorie��6P   $
 auto 6c    6%   �� *Location.Category.Naam+6r     5)      $
 Beschrijving��6^   $	 300 6t    6%   �� *&$Location.Preview.PreviewBeschrijving+ 5*      �� 5+      .�5,      ��  � ��$
 Wrap=�6G   5-      5/        50      $
 Prijs��6H   $
 auto 6W    6%   �� *Location.Prijs+6f   52      �� 53   
   $��Terug naar dashboard��6   $��1��61   $��2��6>   $��Center=�6N   $��Center=�6k   $
��auto��6�   $��TerugNaarDashboard��6�   ���#6abf69���#6abf69+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��6�   ��6�   �� 6�   �� 54   
   $ ��Verwijderen uit favorieten��6   $��1��67   $��0��6D   $��Center=�6T   $��Center=�6q   $
��auto��6�   $!��VerwijderenLocationCustomer��6�   ���#6abf69���#6abf69$ 10��6  ��6�   �� 6  �� 55   
   $��Locatie bekijken��6   $��1��6-   $��1��6:   $��Center=�6J   $��Center=�6g   $
��auto��6�   $��LocatieBekijken��6�   ���#6abf69���#6abf69$ 10��6�   ��6�   �� 6�   �� 56   
   $��Center=�60   $	��Top=�6M   $��2��6e   $��0��6r   $��3��6�   $��18(�6�   $��39��6�   $
��auto��6�   ��6   �� *Foutmelding+6�   58      59      