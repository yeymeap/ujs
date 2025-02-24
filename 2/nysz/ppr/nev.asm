
Code	Segment
	assume CS:Code, DS:Data, SS:Stack

Start:
	mov	ax, Code
	mov	DS, AX

	mov ah, 2
	mov dl, 66
	int 21h 
	mov dl, 111
	int 21h 
	mov dl, 116
	int 21h 
	mov dl, 108
	int 21h 
	mov dl, 111
	int 21h 
	mov dl, 32
	int 21h
	mov dl, 66
	int 21h
	mov dl, 101
	int 21h
	mov dl, 110
	int 21h 
	mov dl, 99
	int 21h
	mov dl, 101
	int 21h 
	mov dl, 32
	int 21h 
	mov dl, 66
	int 21h 
	mov dl, 97
	int 21h 
	mov dl, 108
	int 21h 
	mov dl, 97
	int 21h
	mov dl, 122
	int 21h 
	mov dl, 115
	int 21h
	mov dl, 10
	int 21h 
	mov dl, 42h
	int 21h 
	mov dl, 6fh
	int 21h 
	mov dl, 74h
	int 21h
	mov dl, 6ch
	int 21h
	mov dl, 6fh
	int 21h
	mov dl, 20h
	int 21h
	mov dl, 42h
	int 21h   	
	mov dl, 65h
	int 21h
	mov dl, 6eh
	int 21h
	mov dl, 63h
	int 21h
	mov dl, 65h
	int 21h
	mov dl, 20h
	int 21h	
	mov dl, 42h
	int 21h 
	mov dl, 61h
	int 21h 
	mov dl, 6ch
	int 21h 
	mov dl, 61h
	int 21h 
	mov dl, 7ah
	int 21h 
	mov dl, 73h
	int 21h
	mov dl, 0ah
	int 21h
	mov dl, "B"
	int 21h		
	mov dl, "o"
	int 21h	
	mov dl, "t"
	int 21h	
	mov dl, "l"
	int 21h	
	mov dl, "o"
	int 21h
	mov dl, " "
	int 21h	
	mov dl, "B"
	int 21h	
	mov dl, "e"
	int 21h	
	mov dl, "n"
	int 21h	
	mov dl, "c"
	int 21h	
	mov dl, "e"
	int 21h
	mov dl, " "
	int 21h		
	mov dl, "B"
	int 21h	
	mov dl, "a"
	int 21h		
	mov dl, "l"
	int 21h	
	mov dl, "a"
	int 21h	
	mov dl, "z"
	int 21h	
	mov dl, "s"
	int 21h	
Program_Vege:
	mov	ax, 4c00h
	int	21h

Code	Ends

Data	Segment

Data	Ends

Stack	Segment

Stack	Ends
	End	Start
