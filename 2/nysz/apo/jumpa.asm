Code	Segment
	assume CS:Code, DS:Data, SS:Stack

Start:
	mov	ax, Code
	mov	DS, AX
	
	jmp Two
One:
	mov ah, 9
	mov dx, offset msg1
	int 21h
	
	jmp Program_Vege
Two:
	mov ah, 9
	mov dx, offset msg2
	int 21h
	
	jmp One

Program_Vege:
	mov	ax, 4c00h
	int	21h

msg1: db "Elso mintamondat$"
msg2: db "Masodik mintamondat$"

Code	Ends

Data	Segment

Data	Ends

Stack	Segment

Stack	Ends
	End	Start

