   M S B A M L   `   `   `  ����B  >Dnevnik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:CatalogCatalog  5   	        Catalog.CreateEntityWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Catalog     5   	     � Title$2  ,Создавть новую сущность��5   	   $��449.969��6)   $��331.867��6:    � WindowStartupLocation$ CenterScreen=�6J   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��10 �6   �� 5      $��* �6   �� 5      $��10 �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��10 �6   .+�5   
   �� $��2��6   $��1��6!   $1��+Введите названия полей:��61   �� 5   
   -   5         ��Name$ WarningLabel��5      $��0��6&   $��1��63   $��14(�6C   ���	#FFFF1700$��Calibri)�6h   �� 5   
   $��1��6   $��1��6!   $��0,0,0,5q�61   $7��1Введите название сущности:��6B   �� 5   
   -   5         ��Name$ EntityNameTextBox��5      $��1��6-   $��1��6:   $��	166,0,0,5q�6J   6a   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ newEntityFieldsGrid��5      $��3��60   $��1��6=      AutoGenerateColumns . $	��0,5q�5   *   ��6   �� *Entity+5      �� 50   
   -   5         ��Name$ CreateEntity��50      $��4��6'   $��1��64   $%��Создать сущность��6D   $
��0, 5q�51      $��5q�6   6+   53      54      