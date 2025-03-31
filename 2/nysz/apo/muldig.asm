Code	Segment
	assume CS:Code, DS:Data, SS:Stack

Start:
	mov	ax, Code
	mov	DS, AX
	
	mov al, 3
	mov bl, 4
	mul bl
	; ax = 12
	
	; konvertálás 2 karakterré
	mov cx, 10
	div cl
	; ax = 12 -> al = 1 és ah = 2
	
	mov bx, ax
	; bx = 12 -> bl = 1 és bh = 2
	
	;számértékre tolás
	add bl, 48
	add bh, 48

	; kiíratás
	mov ah, 2
	
	; 1. számérték
	mov dl, bl
	int 21h
	
	; 2. számérték
	mov dl, bh
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

