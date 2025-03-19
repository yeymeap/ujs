Code	Segment
	assume CS:Code, DS:Data, SS:Stack

Start:
	mov	ax, Code
	mov	DS, AX

	mov ah, 9
	mov dx, offset msg1
	int 21h
	
	mov ah, 0
	int 16h
	
	mov ah, 2
	mov dl, al
	mov bl, al
	int 21h
	
	mov dl, 10
	int 21h
	
	mov ah, 9
	mov dx, offset msg2
	int 21h
	
	mov ah, 0
	int 16h
	
	mov ah, 2
	mov dl, al
	mov bh, al
	int 21h
	
	mov dl, 10
	int 21h
	
	mov ah, 9
	mov dx, offset msg3
	int 21h
	
	mov ah, 0
	int 16h
	
	mov ah, 2
	mov dl, al
	mov cl, al
	int 21h
	
	mov dl, 10
	int 21h
	
	sub bl, 48
	sub bh, 48
	sub cl, 48
	
	mov al, bl
	
	mul bh
	
	mov ah, 2
	add al, 48
	mov dl, al
	int 21h
	
	mov dl, 10
	int 21h
	
	mov bl, al
	mov bh, al
	sub bl, 48
	add bl, cl
	add bl, 48
	
	mov dl, bl
	int 21h
	
	mov dl, 10
	int 21h
	
	sub bh, 48
	sub bh, cl
	add bh, 48
	mov dl, bh
	
	mov dl, bh
	int 21h
	

Program_Vege:
	mov	ax, 4c00h
	int	21h
	
msg1 db "Adja meg az elso szamot: $"
msg2 db "Adja meg a masodik szamot: $"
msg3 db "Adja meg mennyivel legyen eltolva a szorzas: $"


Code	Ends

Data	Segment

Data	Ends

Stack	Segment

Stack	Ends
	End	Start

