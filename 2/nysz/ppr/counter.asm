
Code	Segment
	assume CS:Code, DS:Data, SS:Stack

Start:
	mov	ax, Code
	mov	DS, AX
	
	mov cl, 0
	
	mov ah, 0
	int 16h
	mov ah, 2
	add cl, al
	mov dl, cl
	int 21h
	
	mov dl, 10
	int 21h
	
	jmp Evn
	
Odd:
	mov ah, 0
	int 16h
	
	mov ah, 2
	add cl, al
	sub cl, 48
	mov dl, cl
	int 21h
	
	mov dl, 10
	int 21h
	
	jmp Evn
	

Evn:
	mov ah, 0
	int 16h
	
	mov ah, 2
	sub cl, al
	add cl, 48
	mov dl, cl
	int 21h
	
	mov dl, 10
	int 21h
	
	jmp Odd
	

Program_Vege:
	mov	ax, 4c00h
	int	21h



Code	Ends

Data	Segment

Data	Ends

Stack	Segment

Stack	Ends
	End	Start

