   M S B A M L   `   `   `  ����R  NCooperativaConstruccion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:CooperativaConstruccionCooperativaConstruccion  5   	   (    "CooperativaConstruccion.NewProject   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:CooperativaConstruccion     5   	   -   5          � Title$  Nuevo Proyecto��5   	   $	��440��6    $	��465��6-    � 
ResizeMode$ NoResize=�69    � WindowStartupLocation$ CenterScreen=�6O   .��5	      � .+�5
   
   �� $
��Left=�6   $��	30,40,0,0q�6/   $
��Wrap=�6B   $��Nombre del Proyecto:��6V   $	��Top=�6r   �� 5   
   -   5        $��textBox_ProjectName��5      $
��Left=�6-   $��25��6H   $	��250��6T   $��
160,40,0,0q�6`    �� TextWrapping$
 Wrap=�6t   $	��Top=�6�   6�   �� 5   
   $
��Left=�6   $��	30,80,0,0q�6/   $
��Wrap=�6B   $��Monto Inicial:��6V   $	��Top=�6l   �� 5   
   -   5        $ ��textBox_ProjectStartBudget��5      $
��Left=�64   $��25��6O   $	��250��6[   $��
160,80,0,0q�6g   $
 Wrap=�6{   $	��Top=�6�   6�   �� 5   
   $
��Left=�6   $��
30,120,0,0q�6/   $
��Wrap=�6C   $��Fecha Inicio:��6W   $	��Top=�6l   (  "System.Windows.Controls.DatePicker  5   
   -   5        $!��datePicker_ProjectStartDate��5      $
��Left=�68   $	��250��6S   $��160,120,0,0q�6_   $	��Top=�6t   6�   �� 5   
   $
��Left=�6   $��
30,160,0,0q�6/   $
��Wrap=�6C   $��
Fecha Fin:��6W   $	��Top=�6i     5   
   -   5        $��datePicker_ProjectEndDate��5      $
��Left=�66   $	��250��6Q   $��160,160,0,0q�6]   $	��Top=�6r   6�   �� 5   
   $
��Left=�6   $��
30,200,0,0q�6/   $
��Wrap=�6C   $��Estado:��6W   $	��Top=�6f   �� 5   
   -   5        $��comboBox_ProjectStatus��5      $
��Left=�61   $	��250��6L   $��160,200,0,0q�6X   $	��Top=�6m   .@�5      �� -   5        $��Activo��5      $��Activo��6)    �� 
IsSelected . 6:   �� 5      -   5        $��Inactivo��5      $��Inactivo��6+   �� 5      -	   5        $��
Finalizado��5      $��
Finalizado��6-   5      �� 5   
   $
��Left=�6   $��
30,240,0,0q�6/   $
��Wrap=�6C   $��Observaciones:��6W   $	��Top=�6m   �� 5   
   -
   5        $!��textBox_ProjectObservations��5      $
��Left=�65   $	��100��6P   $	��250��6]   $��160,240,0,0q�6i   $
 Wrap=�6~   $	��Top=�6�    �� AcceptsReturn . 6�   �� 5   
   -   5        $��button_SaveProject��5      $��Guardar��6+   $
��Left=�6=   $��75��6X   $��235,355,0,0q�6c   $	��Top=�6x   6�   �� 5   
   -   5        $��button_Cancel��5      $��Cancelar��6&   $
��Left=�69   $��75��6T   $��335,355,0,0q�6_   $	��Top=�6t   6�   5      5      