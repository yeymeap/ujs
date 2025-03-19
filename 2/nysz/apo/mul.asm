Code	Segment
	assume CS:Code, DS:Data, SS:Stack

Start:
	mov	ax, Code
	mov	DS, AX
	
	; ax előkészítése
	; mul op
	; ax-ben mentőtdik el az eredmény
	; ax = ah & al
	; pl 2*4
	
	mov al, 2
	mov bl, 4	
	
	mul bl ; eredmény al-ben
	
	mov ah, 2
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

