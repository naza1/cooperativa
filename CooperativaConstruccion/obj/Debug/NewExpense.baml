   M S B A M L   `   `   `  ����R  NCooperativaConstruccion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:CooperativaConstruccionCooperativaConstruccion  5   	   (    "CooperativaConstruccion.NewExpense   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:CooperativaConstruccion     5   	   -   5          � Title$  Nuevo Gasto / Jornal��5   	   $	��440��6&   $	��465��63    � 
ResizeMode$ NoResize=�6?    � WindowStartupLocation$ CenterScreen=�6U   .��5	      � .+�5
   
   �� $
��Left=�6   $��	30,40,0,0q�6/   $
��Wrap=�6B   $��Tipo:��6V   $	��Top=�6c   �� 5   
   -   5        $��comboBox_ExpenseType��5      $
��Left=�6/   $	��250��6J   $��
160,40,0,0q�6V   $	��Top=�6j   .@�5      �� -   5        $��Gasto��5      $��Gasto��6(    �� 
IsSelected . 68   �� 5      -   5        $��Jornal��5      $��Jornal��6)   5      �� 5   
   $
��Left=�6   $��	30,80,0,0q�6/   $
��Wrap=�6B   $��Nombre:��6V   $	��Top=�6e   �� 5   
   -   5        $��textBox_ExpenseName��5      $
��Left=�6-   $��25��6H   $	��250��6T   $��
160,80,0,0q�6`    �� TextWrapping$
 Wrap=�6t   $	��Top=�6�   6�   �� 5   
   $
��Left=�6   $��
30,120,0,0q�6/   $
��Wrap=�6C   $��	Cantidad:��6W   $	��Top=�6h   �� 5   
   -   5        $��textBox_ExpenseAmount��5      $
��Left=�6/   $��25��6J   $��70��6V   $��160,120,0,0q�6a   $
 Wrap=�6v   $	��Top=�6�   6�   �� 5   
   $
��Left=�6   $��240,120,0,0q�6/   $
��Wrap=�6D   $��Precio Unitario:��6X   $	��Top=�6p   �� 5   
   -   5        $��textBox_ExpenseUnitPrice��5      $
��Left=�62   $��25��6M   $��80��6Y   $��330,120,0,0q�6d   $
 Wrap=�6y   $	��Top=�6�   6�   �� 5   
   $
��Left=�6   $��
30,160,0,0q�6/   $
��Wrap=�6C   $��Precio Total:��6W   $	��Top=�6l   �� 5   
   -   5        $��textBox_ExpenseTotalPrice��5      $
��Left=�63   $��25��6N   $	��250��6Z   $��160,160,0,0q�6f   $
 Wrap=�6{   $	��Top=�6�    �� 
IsReadOnly . 6�   �� 5   
   $
��Left=�6   $��
30,200,0,0q�6/   $
��Wrap=�6C   $��N° de Comprobante:��6W   $	��Top=�6q   �� 5   
   -	   5        $"��textBox_ExpenseVoucherNumber��5      $
��Left=�66   $��25��6Q   $	��250��6]   $��160,200,0,0q�6i   $
 Wrap=�6~   $	��Top=�6�   6�   �� 5   
   $
��Left=�6   $��
30,240,0,0q�6/   $
��Wrap=�6C   $��Descripción:��6W   $	��Top=�6k   �� 5   
   -
   5        $ ��textBox_ExpenseDescription��5      $
��Left=�64   $	��100��6O   $	��250��6\   $��160,240,0,0q�6h   $
 Wrap=�6}   $	��Top=�6�    �� AcceptsReturn . 6�   �� 5   
   -   5        $��button_SaveExpense��5      $��Guardar��6+   $
��Left=�6=   $��75��6X   $��235,355,0,0q�6c   $	��Top=�6x   6�   �� 5   
   -   5        $��button_Cancel��5      $��Cancelar��6&   $
��Left=�69   $��75��6T   $��335,355,0,0q�6_   $	��Top=�6t   6�   5      5      