   M S B A M L   `   `   `  ����F  BProject_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Project_WPF.ViewsProject_WPF.Views  5   	   .    (Project_WPF.Views.GekozenDuiklocatieView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Project_WPF.Views     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��16(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$) #Locatie bekijken - JP Duik Locaties��5   	   $	��400��65   $	��700��6B   .��5      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      .+�5!   
   �� $��Gegevens locatie ��6   $
��Left=�6,   $��Center=�6G   $��20(�6b   $��0��6|   $��0��6�   $��2��6�   $��39��6�   $
��auto��6�   $��30,0,0,0q�6�   �� 5"   
   -   5         ��Name$ txtNaam��5"       �� 
IsReadOnly . )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Naam:��6K    % !MaterialDesignFloatingHintTextBox#��[ 5#      $��1��6M   $��0��6Z   $
��auto��6k   $
��auto��6y   $��	5,0.4,5,0q�6�   ��5"   5   �� *Naam+5#   �   �� 5$   
   -   5        $ txtGeschiktheid��5$       . $ Geschiktheid:��6[   #��[ 5%      $��1��6M   $��1��6Z   $
��auto��6k   $
��auto��6y   $��	5,0.4,5,0q�6�   ��5$   =   �� *Geschiktheid+5%   �   �� 5&   
   -   5        $ txtPrijs��5&       . $ Prijs:��6M   #��[ 5'      $��2��6M   $��0��6Z   $
��auto��6j   $
��auto��6x   $��	5,0.4,5,0q�6�   ��5&   6   �� *Prijs+5'   �   �� 5(   
   -   5        $ txtLand��5(       . $ Land:��6K   #��[ 5)      $��3��6M   $��0��6Z   $
��auto��6j   $
��auto��6x   $��	5,0.4,5,0q�6�   ��5(   5   �� *Land+5)   �   �� 5*   
   -   5        $ txtStad��5*       . $ Stad:��6K   #��[ 5+      $��3��6M   $��1��6Z   $
��auto��6j   $
��auto��6x   $��	5,0.4,5,0q�6�   ��5*   5   �� *Stad+5+   �   �� 5,   
   -   5        $ 	txtStraat��5,       . $ Straat:��6O   #��[ 5-      $��4��6M   $��0��6Z   $��2��6j   $
��auto��6~   $
��auto��6�   $��	5,0.4,5,0q�6�   ��5,   7   �� *Straat+5-   �   �� 5.   
   -   5        $ txtHuisnummer��5.       . $ Huisnummer:��6W   #��[ 5/      $��5��6M   $��0��6Z   $
��auto��6k   $
��auto��6y   $��	5,0.4,5,0q�6�   ��5.   ;   �� *
Huisnummer+5/   �   �� 50   
   $��1��60   $��5��6A   $��25��6N   
���  ����6   �� *Foutmelding+6Z   �� 52   
   -   5        $ 	txtDiepte��52       . $ Diepte:��6O   #��[ 53      $��2��6M   $��1��6Z   $
��auto��6j   $
��auto��6x   $��	5,0.4,5,0q�6�   ��52   7   �� *Diepte+53   �   �� 54   
   -	   5        $ txtCategorie��54       . $ 
Categorie:��6U   #��[ 55      $��4��6M   $��1��6Z   $
��auto��6j   $
��auto��6x   $��	5,0.4,5,0q�6�   ��54   :   �� *	Categorie+55   �   �� 56   
   -
   5        $ txtBeschrijving��56       . $ Beschrijving:��6f   #��[ 57       �� TextWrapping$
 Wrap=�6M   $��1��6a   $��2��6n   $��2��6~   $��3��6�   $
��auto��6�   $
��auto��6�   $��	5,0.4,5,0q�6�   ��56   =   �� *DescriptionBeschrijving+57   �   �� 58   
   -   5        $ 
txtPreview��58       . $ Preview:��6]   #��[ 59      $
 Wrap=�6M   $��4��6a   $��2��6n   $��2��6~   $��2��6�   $
��auto��6�   $
��auto��6�   $��	5,0.4,5,0q�6�   ��58   8   �� *PreviewBeschrijving+59   �   �� 5:   
   $��Terug naar dashboard��6   $��6��61   $��3��6>   $��Center=�6N   $��Center=�6k   $
��auto��6�   $��TerugNaarDashboard��6�   ���#6abf69���#6abf69+  %MaterialDesignThemes.Wpf.ButtonAssist	   CornerRadius$	 10��6�   ��6�   �� 6�   �� 5;   
   $��Toevoegen aan favorieten��6   $��6��65   $��0��6B   $��2��6R   $��Center=�6f   $��Center=�6�   $
��auto��6�   $��ToevoegenLocationCustomer��6�   ���#6abf69���#6abf69$	 10��6  ��6�   �� 6  5=      5>      