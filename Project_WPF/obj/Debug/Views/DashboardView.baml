   M S B A M L   `   `   `  ����F  BProject_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Project_WPF.ViewsProject_WPF.Views  5   	   %    Project_WPF.Views.DashboardView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Project_WPF.Views     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5   	   $��Regular"�5	   	   $��16(�5
   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$" Dashboard - JP Duik Locaties��5   	   $	��325��6.   $	��500��6;   .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      $	��250 �6   �� 5      $	��250 �6   ��5   
   �� 5       �� ImageSource$ ../Img/dashboard.jpg��6    j� Stretch$ UniformToFill=�6<    �� Opacity$	 0.4Q�6T   .+�5   
   �� $��	Dashboard��6   $
��Left=�6$   $��Center=�6?   $��20(�6Z   $��0��6t   $��0��6�   $��2��6�   $��39��6�   $
��auto��6�   $��30,0,0,0q�6�   �� 5    
   $��Duiklocaties bekijken��6   $��1��62   $��0��6?   $��2��6O   $��0q�6c   $��10q�6o   $��Center=�6{   $	��Top=�6�   $	��350��6�   $��50��6�   $��DuiklocatiesBekijken��6�   ���#6abf69���#6abf69+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��60  ��6�   �� 6`  �� 5!   
   $��Account instellingen��6   $��2��61   $��0��6>   $��2��6N   $��0q�6b   $��10q�6n   $��Center=�6z   $	��Top=�6�   $	��350��6�   $��50��6�   $��AccountInstellingen��6�   ���#6abf69���#6abf69$ 10��6.  ��6�   �� 6^  �� 5"   
   $��
Favorieten��6   $��3��6'   $��0��64   $��2��6D   $��0q�6X   $��10q�6d   $��Center=�6p   $	��Top=�6�   $	��350��6�   $��50��6�   $��
Favorieten��6�   ���#6abf69���#6abf69$ 10��6  ��6�   �� 6K  5#      5$      