Code	Segment
	assume CS:Code, DS:Data, SS:Stack

Start:
	mov	ax, Code
	mov	DS, AX
	
	; input
	mov ah, 0
	int 16h
	
	; move user input, write out
	mov ah, 2
	mov dl, al
	mov bl, al
	int 21h
	
	; line break
	mov dl, 10
	int 21h
	
	; input
	mov ah, 0
	int 16h
	
	; move user input, write out
	mov ah, 2
	mov dl, al
	mov bh, al
	int 21h
	
	; line break
	mov dl, 10
	int 21h
	
	; sub from input
	sub bl, 48
	sub bh, 48
	
	; multiply and divide
	mov al, bl
	mul bh
	mov cx, 10
	div cl
	
	; shift to numbers
	mov bx, ax
	add bl, 48
	add bh, 48
	
	; write out
	mov ah, 2
	mov dl, bl
	int 21h
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

