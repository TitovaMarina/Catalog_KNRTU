   M S B A M L   `   `   `  ����B  >Dnevnik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:CatalogCatalog  5   	   *    $Catalog.CreateInstanceOfEntityWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Catalog     5   	     � Title$  Документ��5   	   $��483.943��6   $��318.46��6+    � WindowStartupLocation$ CenterScreen=�6:   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��20 �6   �� 5      $
��0.5* �6   �� 5      $��20 �6   �� 5      $
��0.5* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $��10 �6   �� 5      $
��auto �6   �� 5      $��20 �6   .+�5!   
   �� -   5         ��Name$ 
FieldsList��5!      $��1��6(   $��1��65   $��3��5"       �� View 5#      �� 5$      .P�5%      �� -   5        FieldsNames��$(��"Наименование поля ��5%   :    �� Width$	 130��6V    �� CellTemplate 5&      �� 5'      .R�5(   "   �� $
��Wrap=�6H   $��2q�6\   
���   ���6,   ��  �� Path$ Title�5)   C   5*      5,      �� 5-      -   5        FieldsValues��$��Значение поля��5-   ;    5.      �� 5/      .R�50   "   �� 	 �� TextWrapping$
	 Wrap=�6H   $��2q�6\   $��3q�6g   $��80��6s   
���   ���6+   �� $ FValue�51   C   52      54      55      57      �� 5;   
   -   5        
 ��Name$
 Accept��5;      $��3��6!   $��1��6.    �� 	IsDefault . .��5<   &   OK6*   �� 5=   
   -   5        $
 Cancel��5=       �� IsCancel . $��3��61   $��3��6>   .��6c   Отмена6k   5A      5B      