   M S B A M L   `   `   `  ����B  >Dnevnik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:CatalogCatalog  5   	       Catalog.LoginWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Catalog     5   	     � Title$  Авторизация��5   	   $��220.444��6   $��288.301��6.    � 
ResizeMode$ NoResize=�6>    � WindowStartupLocation$ CenterScreen=�6T   ��5	      �� 5
   
    �� ImageSource$ 
forest.jpg��6   ��5      �� 5   
   $ 
forest.jpg��6   .��5      �  � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��0.3* �6   �� 5      $��20 �6   �� 5      $
��0.7* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��20 �6   .+�5"   
   �� $��
Логин��6   $��1��6!   $��1��61   
���   � J� OpacityMask �	#FFFFCFCF �� TextAlignment$ Right=�6i   �� 5#   
   -   5         ��Name$ LogintextBox��5#      $��3��6(   $��1��68   6E   �� 5%   
   $��Пароль��6   $��1��6"   $��3��62   $ Right=�6?   G� 5&   
   -   5        	 G�Name$	 PasswordBox��5&      $��3��6+   $��3��6;   6H   �� 5(   
   -   5        
 ��Name$
 warningLabel��5(      $��1��6&   $��4��66   $��3��6C   $6��0Неверный логин или пароль.��5)      $��Arial)�65   $��10(�6H   
���  ��$y�Hidden=�6g   $��Center=�6{   $��Center=�6�   ��5*      �� 5+       �� Color$ White��6"    �� Opacity$	 0.7Q�60   5-      �� 5/   
   -   5         ��Name$ loginButton��5/      $��1��6&   $��5��66   $��3��6C   $��
Войти��50      $	��0,5q�6!   ���	#FF2FFF3151   (   �� 52   
   -   5        $ registrationButton��52      $��1��6-   $��6��6=   $��3��6J   $��Регистрация��53      $	��0,5q�6'   
��� ���54   %   56      57      