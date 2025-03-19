Code	Segment
	assume CS:Code, DS:Data, SS:Stack

Start:
	mov	ax, Code
	mov	DS, AX

	mov ah, 0 
	int 16h
	
	mov ah, 2
	mov bl, al
	sub bl, 48
	mov dl, al
	int 21h
	
	mov dl, 10
	int 21h
	
	mov ah, 0
	int 16h
	
	mov ah, 2
	mov cl, al
	sub cl, 48
	mov dl, al
	int 21h
	
	mov dl, 10
	int 21h
	
	mov al, cl
	
	mul bl
	
	mov ah, 2 ; szorzás felülírja egész regisztert
	mov dl, al
	add dl, 48
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

