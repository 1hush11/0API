   M S B A M L   `   `   `  ����G  C0auth_client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:_0auth_client_0auth_client  5   	       _0auth_client.Admin   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:_0auth_client     5   	     � Title$  Admin��5   	   $	��700��6   $	��800��6$   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��1.5* �6   �� 5      $��* �6   �� 5      $��7* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   � $��2��6    5      �� 5      $��* �6#   �� 5      $
��0.5* �6#   �� 5      $��2* �6#   �� 5      $��* �6#   .+�5      �� -   5         ��Name$ logOutBT��5      $��
Выйти��6'   $��0,8,0,0q�67   $��Center=�6H   $��75��6e   $��32��6p   $	��Top=�6|   6�   �� 5      -   5         ��Name$ 
usernameLB��5      $��2��6(   $��2��68   $��Иванов Иван��6L   $��Center=�6b   $��16(�6}   $	��250��6�   $��Right=�6�   $��	273,0,0,0q�6�   5      �� 5   
   $��Товары��6   $��1��6!   $��0,3,10,0q�6.   $��Right=�6@   $��75��6\   $��32��6g   $	��Top=�6s   �� 5    
   -   5        $ exportProdBT��5       $#��Экспорт товаров��6'   $��1��6A   $��1��6N   $��10,0,0,0q�6^   $
��Left=�6p   $	��180��6�   $��40��6�   $	��Top=�6�   6�    � 5"   
   -   5          �Name$ 
edit_frame��5"        � NavigationUIVisibility$ Hidden=�6$   $��2��6D   $��2��6Q   $��2��6b   � 5$   
   $��2��6   $��2��6   $��2��60    5%      �� 5&      $��3* �6    �� 5'      $��7* �6    �� 5(      $��* �6    .+�5+      � $��0��6    5,      �� 5-      $��* �6'   �� 5.      $��* �6'   .+�50      �� -   5         ��Name$ countTB��50      $��Right=�6-   $��Center=�6I   �� 51      -   5        $ addProductBT��51      $��1��6/   $��10,0,0,0q�6?   $��50��6Q   $��Center=�6]   $
��Left=�6x   .��52      ��  �� TextAlignment$ Center=�6    $	��105��67   + добавить�� 6P   
товар6c   53      54      &   System.Windows.Controls.DataGrid  55      -   5        	  Name$	 
productsDG��55      $��1��6+   
   AutoGenerateColumns$
 False��68      SelectionMode$ Single=�6T      SelectionUnit$ FullRow=�6k      
IsReadOnly$
 True��6�   ���#252526   Columns 56      4  .System.Windows.Controls.DataGridTemplateColumn  57      ,  &System.Windows.Controls.DataGridColumn   Header$ Уд.��6-      CellTemplate 58      �� 59      .R�5:   "   �� $ 
deleteProd��6P   -   5           smallBUTStyle#��[  5:   )   .��6}   уд.6�   5;      5=      0  *System.Windows.Controls.DataGridTextColumn  5>      $ Артикул��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 6c      
IsReadOnly$
 True��6n   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *ProductArticleNumber+6n     5?      $ Наименование��6)   $ 2* 6_   $
 True��6j    6?   �� *NameProduct+6j     5@      $ Стоимость��6)   $ 1* 6\   $
 True��6g    6<   �� *CostProduct+6g     5A      $ Описание��6)   $ 3* 6b   $
 True��6m    6;   �� *DescriptionProduct+6m     5B      $ Тип��6)   $ 1* 6X   $ False��6c    66   �� *IdProductType+6c     5C      $ Фото��6)   $
 1.5* 6X   $ False��6e    67   �� *PhotoProduct+6e     5D      $ Поставщик��6)   $ 1* 6[   $ False��6f    6<   �� *
IdSupplier+6f     5E      $ Макс. скидка��6)   $ 1* 6_   $ False��6j    6?   �� *MaxDiscount+6j     5F      $  Производитель��6)   $ 1* 6c   $ False��6n    6@   �� *IdManufacturer+6n     5G      $ Тек. скидка��6)   $ 1* 6b   $ False��6m    6>   �� *CurrentDiscount+6m     5H      $ Кол-во��6)   $ 1* 6]   $ False��6h    69   �� *QuantityInStock+6h     5I      $ Ред.��6-    5J      �� 5K      .R�5L   "   �� $ editProd��6P   -	   5        #��[  5L   )   $��ред.��6b   6q   5M      5O      5Q       � 5R      -
   5        $ 	contentFR��5R      $��3��6'   $ Hidden=�68   5S      5T      5U      