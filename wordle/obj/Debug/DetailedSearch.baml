   M S B A M L   `   `   `  ����A  =wordle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:wordlewordle  5   	       wordle.DetailedSearch   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:wordle     5   	   -   5          � Title$  DetailedSearch��5   	   $	��500��6    $	��800��6-   .��5	      � -   5         �Name$ FirstPlaceDelete��5	      .+�5
   
   �� -   5         ��Name$ SearchResults��5
      $
��Left=�6)   $	��147��6D   $	��Top=�6Q   $	��772��6i   $��
10,312,0,0q�6u   �� 5   
   $9��3The list of words that meet the requirements above:��6   $
��Left=�6N   $	��Top=�6i   $��
10,281,0,0q�6�   $	��392��6�   �� 5   
   $e��_Select the letters which you know are in the right position (leave it as is if you don't know):��6   $
��Left=�6z   $	��Top=�6�   $��	10,10,0,0q�6�   $	��496��6�   �� 5   
   $����Select the letter and it's place which are in the word, but not in the correct position (select which position they are not in):��6   $
��Left=�6�   $	��Top=�6�   $��	10,80,0,0q�6�   $	��606��6�   $��11(�6�   �� 5   
   $3��-Write letters here which are not in the word:��6   $
��Left=�6H   $	��Top=�6c   $��
10,212,0,0q�6{   $	��229��6�   $��11(�6�   �� 5   
   -   5         ��Name$ LettersNotInIt��5      $
��Left=�6*   $��23��6E    �� TextWrapping$
 Wrap=�6Q   $	��Top=�6e   $	��543��6}   $��239,212,0,0q�6�   6�   �� 5   
   -   5         ��Name$ 	SearchBtn��5      $��Search��6$   $
��Left=�65   $	��Top=�6P   $	��772��6h   $��
10,256,0,0q�6t   6�   �� 5   
   -   5         ��Name$ FirstLetter��5      $
��Left=�6(   $	��Top=�6C   $��50��6[   $��
506,14,0,0q�6f    J� RenderTransformOrigin$ 0.567,1.455&�6z    �� SelectedIndex$ 0��6�   �� 5   
   -   5        $ SecondLetter��5      $
��Left=�6)   $	��Top=�6D   $��50��6\   $��
561,14,0,0q�6g   $ 0.567,1.455&�6{   $ 0��6�   �� 5   
   -   5        $ ThirdLetter��5      $
��Left=�6(   $	��Top=�6C   $��50��6[   $��
616,14,0,0q�6f   $ 0.567,1.455&�6z   $ 0��6�   �� 5   
   -	   5        $ FourthLetter��5      $
��Left=�6)   $	��Top=�6D   $��50��6\   $��
671,14,0,0q�6g   $ 0.567,1.455&�6{   $ 0��6�   �� 5   
   -
   5        $ 
FithLetter��5      $
��Left=�6'   $	��Top=�6B   $��50��6Z   $��
726,14,0,0q�6e   $ 0.567,1.455&�6y   $ 0��6�   �� 5   
   -   5        $ 
FirstPlace��5      $
��Left=�6&   $��35��6A   $	��Top=�6M   $��50��6e   $��
10,110,0,0q�6p   �� 5   
   -   5        $ SecondPlace��5      $
��Left=�6'   $��35��6B   $	��Top=�6N   $��50��6f   $��110,110,0,0q�6q   �� 5   
   -   5        $ 
ThirdPlace��5      $
��Left=�6&   $��35��6A   $	��Top=�6M   $��50��6e   $��210,110,0,0q�6p   �� 5   
   -   5        $ FourthPlace��5      $
��Left=�6'   $��35��6B   $	��Top=�6N   $��50��6f   $��310,110,0,0q�6q   �� 5   
   -   5        $ 	FithPlace��5      $
��Left=�6%   $��35��6@   $	��Top=�6L   $��50��6d   $��410,110,0,0q�6o   �� 5   
   -   5        $ 
WhatLetter��5      $
��Left=�6'   $	��Top=�6B   $��50��6Z   $��
616,83,0,0q�6e   $ 0.567,1.455&�6y   �� 5   
   -   5        $ WhereIsItNot��5      $
��Left=�6)   $	��Top=�6D   $��50��6\   $��
671,83,0,0q�6g   $ 0.567,1.455&�6{   �� 5   
   -   5        $ AddItInTheList��5      $��Add it��6)   $
��Left=�6:   $	��Top=�6U   $��56��6m   $��
726,83,0,0q�6x   $��22��6�   6�   �� 5   
   -   5        $ DeleteFirstSelected��5      $��Delete
selected��6.   $
��Left=�6Q   $	��Top=�6l   $��50��6�   $��
10,150,0,0q�6�   $��40��6�   6�   �� 5   
   -   5        $ DeleteSecondSelected��5      $��Delete
selected��6/   $
��Left=�6M   $	��Top=�6h   $��50��6�   $��110,150,0,0q�6�   $��40��6�   6�   �� 5    
   -   5        $ DeleteThirdSelected��5       $��Delete
selected��6.   $
��Left=�6L   $	��Top=�6g   $��50��6   $��210,150,0,0q�6�   $��40��6�   6�   �� 5!   
   -   5        $ DeleteFourthSelected��5!      $��Delete
selected��6/   $
��Left=�6M   $	��Top=�6h   $��50��6�   $��310,150,0,0q�6�   $��40��6�   6�   �� 5"   
   -   5        $ DeleteFithSelected��5"      $��Delete
selected��6-   $
��Left=�6K   $	��Top=�6f   $��50��6~   $��410,150,0,0q�6�   $��40��6�   6�   5$      5%      