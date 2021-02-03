# -*- coding: cp936 -*-
import re
import linecache
import numpy as np
import os


#數值文本文件直接轉換爲矩陣數組形式方法二
def txt_to_matrix(r'FaceList.txt'):
    file=open(r'FaceList.txt')
    lines=file.readlines()
     print(lines)
    #['0.94\t0.81\t...0.62\t\n', ... ,'0.92\t0.86\t...0.62\t\n']形式
    rows=len(lines)#文件行數

    datamat=np.zeros((rows,8))#初始化矩陣

    row=0
    for line in lines:
        line=line.strip().split('\t')#strip()默認移除字符串首尾空格或換行符
        datamat[row,:]=line[:]
        row+=1
    return datamat