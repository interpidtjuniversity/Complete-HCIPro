   M S B A M L   `   `   `  ����I  EKinectExplorer, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:Microsoft.Samples.Kinect.KinectExplorer'Microsoft.Samples.Kinect.KinectExplorer  5   	   ^ ZMicrosoft.Samples.Kinect.WpfViewers, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null�^clr-namespace:Microsoft.Samples.Kinect.WpfViewers;assembly=Microsoft.Samples.Kinect.WpfViewers#Microsoft.Samples.Kinect.WpfViewers 5   	   :    4Microsoft.Samples.Kinect.KinectExplorer.KinectWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Glocal5clr-namespace:Microsoft.Samples.Kinect.KinectExplorer     5   	   mkt^clr-namespace:Microsoft.Samples.Kinect.WpfViewers;assembly=Microsoft.Samples.Kinect.WpfViewers     5   	   -   5          � Title$  Kinect Explorer��5   	   $	��854��6!   $	��722��6-    � 	Resources 5       �� MergedDictionaries �� SourceL   FMicrosoft.Samples.Kinect.KinectExplorer.KinectWindowsViewerSwapCommand   SwapCommand�� 5   
    5	      �� 5
      $f `pack://application:,,,/Microsoft.Samples.Kinect.WpfViewers;component/KinectControlResources.xaml?�6%   %   &	          5      63   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [  5      6@    J� InputBindings 5      �� 5   
   
 �� Key$
 Back��6    �� Command# [  6!   .��5      � -   5        $��
layoutGrid��5      $��	10,0,-6,4q�6     
KinectFont#��[ 60   ��5   
   �� 5      	 �� ImageSource$3	 -C:\Users\DELL\Pictures\Saved Pictures\bk1.png��6   
 � RowDefinitions
 5   
   �� 5      $
��Auto �6   �� 5      $	��59* �6   $	��300��6)   �� 5      $	��27* �6   �� 5!      $
��Auto �6    � ColumnDefinitions 5#   
   �� 5%      $	��400��6   �� 5&      $��0* �6   �� 5(      $
��Auto �6   $��216.8��6,   .+�5+   
   � $��0��6   $��1��6   $��10,0,215,10q�6,   $��3��6A   
 5,      �� 5-      $
��213* �6    �� 5.      $
��217* �6    .+�50      � -   5        $��MainViewerHost��50      $��2��6)   .+�51      � -   5        $��ColorVis��51        DarkNeutralBrush#��[ 6'   $��	0,0,0.2,0q�6V   .+�52      (� $��Center=�6   $��Center=�6;    (� Stretch$ Uniform=�6V   .��54      � .+�55      ;  5Microsoft.Samples.Kinect.WpfViewers.KinectColorViewer  -   5          Name$ ColorViewer��55   3   6  0Microsoft.Samples.Kinect.WpfViewers.KinectViewer   CollectFrameRate .     RetainImageOnSensorChange . 7  1Microsoft.Samples.Kinect.WpfViewers.KinectControl   KinectSensorManager 6H   �� *KinectSensorManager+6�   �� 56      .+�57   "   >  8Microsoft.Samples.Kinect.WpfViewers.KinectSkeletonViewer  -   5          Name$ KinectSquatSkeletonViewer��57   :      	ImageType$ Color=�5<   %    58   %   �� *KinectSensorManager+y�59   %   �� *(&KinectSensorManager.ColorStreamEnabled+  BoolToVisibilityConverter �� 	Converter# [ ��5:   %   ��  �� ElementName$ ColorViewer�� �� Path$ ActualWidth���5;   %   �� $ ColorViewer��$ ActualHeight�5<   %   5>      5?      5@      �� 5B      ���#7777 J� SnapsToDevicePixels . $	��462��6�   $��Bottom=�6�   $��	0,0,0,0.4q�6�   y�6-   �� *(&KinectSensorManager.ColorStreamEnabled+# [  �� ConverterParameter$
 True��6�   5C      5D      5E      � 5F   
   -   5         �Name$ Example��5F      $��10,3,293.2,0q�6    $��2��66   .+�5H      ��  J� RenderTransformOrigin$ 0.178,0.621&�6   .+�5I      r� -	   5         r�Name$ mediaElement��5I      $
��Left=�65   $	��179��6P   $	��Top=�6]   $	��320��6u    r� Source$- 'C:/Users/DELL/Videos/Captures/squat.mp4?�6�   $ 0.386,0.753&�6�    �� Left$ 1��6�   �� 5J      -
   5         ��Name$ btnPlay��5J      $
��Play��6*   $
��Left=�69   $	��Top=�6T   $��30��6l   
 �� Top$	 185��6�   $��21��6�   $ 1��6�   $ 0.604,0.819&�6�   �� 5K      -   5        $ btnPause��5K      $��Pause��6+   $	��Top=�6;   $��40��6j   $	 133��6u   $	 185��6�   $ 0.54,-0.194&�6�   �� 5L      -   5        $ btnStop��5L      $
��Stop��6*   $	��Top=�69   $��33��6Q   $	 288��6r   $	 185��6�   $��21��6�   $ 0.624,1.171&�6�   5M      5N      �� 5P   
    �� Orientation$ Vertical=�5Q      $��1��5R      $��	6.8,0,0,0q�5S      $
��Left=�5T      $	��198��6(   $��2��64   $��2��6E   $	��688��6U   $	��Top=�6b   .+�5U      8  2Microsoft.Samples.Kinect.WpfViewers.KinectSettings  -   5        $��
0,20,0.4,0q�5U   T    . $	��159��6�   $ 0.894,1.414&�6�   $
��Auto��6�    6    �� *KinectSensorManager+6�   � 5V      $	��140��6   $��	0,0,0.4,0q�6     5W      .+�5Y      �� -   5          ��Name$  label��5Y      $��Squat��6+   
�������$��20(�6K   $��60,46,75,63q�6Y   $ 0.549,1.067&�6n   �� 5Z      -   5        $  LittleGrade��5Z      
���  ��$��20(�6B   ! �� TextAlignment$! Center=�6P   $ 0.364,0.329&�6g   $��120,46,40,63q�6�   �� 5[      -   5        $  Total��5[      $
��/100��6+   
�������$��20(�6J   $��158,46,0,63q�6X   $ 0.549,1.067&�6m   � 5\      -   5        " �Name$" GradeProgress��5\      $��36��65   $��60,82,17,22q�6A   $ 
0.91,0.581&�6V   
����p��6y   �� 5]      -   5        # ��Name$# Squatpe��5]      $5��/C:\Users\DELL\Pictures\Saved Pictures\squat.png��6)   $��64��6b   $��0,64,143,12q�6n   $ 0.503,1.131&�6�   5^      5_      �� 5`   
   -   5        $  labelprogress��5`      
�������$��35(�6>   $! Center=�6L   $ 0.364,0.329&�6c   $��339,23,125.2,135q�6�   $��2��6�   $��
Progress: ��6�   �� 5a   
   -   5        $  Grade��5a      
�������$��35(�66   $! Center=�6D   $ 0.364,0.329&�6[   $��507,23,55.2,135q�6   $��2��6�   �� 5b   
   -   5        $  	baifenhao��5b      
�������$��35(�6:   $! Center=�6H   $ 0.364,0.329&�6_   $��577,23,5.2,135q�6�   $��2��6�   $��%��6�   �� 5c   
   -   5        $ ��Name$$ clock��5c      $��404,86,55.2,86q�6!   $ 0.72,3.8&�69   $��2��6Z   
�������$��30(�6z   % �� TextAlignment$% Center=�6�   $��0q�6�   .��6�   ��5d      �� 5e      $3	 -C:\Users\DELL\Pictures\Saved Pictures\bk2.png��6   .��5f   "   5g      �� 5h   
   -   5        $
 btn1��5h      $��472,130,115.2,46q�6   $ 0.583,4.824&�69   $��2��6]   $��0q�6j   ��5i      �� 5j      $3	 -C:\Users\DELL\Pictures\Saved Pictures\bk3.png��6   5l      5m      5n      