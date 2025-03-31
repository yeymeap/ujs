Code	Segment
	assume CS:Code, DS:Data, SS:Stack

Start:
	mov	ax, Code
	mov	DS, AX
	
	; write out msg0
	mov ah, 9
	mov dx, offset msg0
	int 21h
	
	; line break
	mov ah, 2
	mov dl, 10
	int 21h
	
	; write out msg1
	mov ah, 9
	mov dx, offset msg1
	int 21h
	
	; input number
	mov ah, 0
	int 16h
	
	; write out number, copy in bl
	mov ah, 2
	mov dl, al
	mov bl, al
	int 21h
	
	; line break
	mov dl, 10
	int 21h
	
	; calculate perimeter
	sub bl, 48
	mov al, bl
	mov dh, bl
	mov bl, 4
	mul bl
	mov cx, 10
	div cl
	mov cl, dh
	mov bx, ax
	
	; add 48
	add bh, 48
	add bl, 48
	
	; write out msg2
	mov ah, 9
	mov dx, offset msg2
	int 21h
	
	; write out perimeter
	mov ah, 2
	mov dl, bl
	int 21h
	mov dl, bh
	int 21h
	
	; line break
	mov dl, 10
	int 21h
	
	; calculate area
	mov al, cl
	mul al
	mov cx, 10
	div cl
	mov bx, ax
	
	; add 48
	add bl, 48
	add bh, 48
	
	; write out msg3
	mov ah, 9
	mov dx, offset msg3
	int 21h
	
	; write out area
	mov ah, 2
	mov dl, bl
	int 21h
	mov dl, bh
	int 21h
	
Program_Vege:
	mov	ax, 4c00h
	int	21h
	
msg0 db "Negyzet kerulete es terulete$"
msg1 db "Negyzet oldala: $"
msg2 db "Kerulet: $"
msg3 db "Terulet: $"

Code	Ends

Data	Segment

Data	Ends

Stack	Segment

Stack	Ends
	End	Start

