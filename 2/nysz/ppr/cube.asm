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
	
	; calculate volume
	sub bl, 48
	mov dh, bl
	mov al, bl
	mul bl
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
	mov dx, offset msg3
	int 21h
	
	; write out volume
	mov ah, 2
	mov dl, bl
	int 21h
	mov dl, bh
	int 21h
	
	; line break
	mov dl, 10
	int 21h
	
	; sub 48, calculate surface, divide to two characters
	mov bl, cl
	mov al, bl
	mul bl
	mov bl, 6
	mul bl
	mov cx, 10
	div cl
	mov bx, ax
	
	; add 48 
	add bl, 48
	add bh, 48
	
	; write out msg3
	mov ah, 9
	mov dx, offset msg2
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
	
msg0 db "Kocka felszin es terfogatszamitas$"
msg1 db "Kocka oldala: $"
msg2 db "Felszin: $"
msg3 db "Terfogat: $"

Code	Ends

Data	Segment

Data	Ends

Stack	Segment

Stack	Ends
	End	Start

