Code	Segment
	assume CS:Code, DS:Data, SS:Stack

Start:
	mov	ax, Code
	mov	DS, AX
	
	; write out msg1
	mov ah, 9
	mov dx, offset msg1
	int 21h
	
	; input number
	mov ah, 0
	int 16h
	
	; write out inputted number, move inputted number to bl
	mov ah, 2
	mov dl, al
	mov bl, al
	int 21h
	
	; line break
	mov dl, 10
	int 21h
	
	; write out msg2
	mov ah, 9
	mov dx, offset msg2
	int 21h
	
	; input number
	mov ah, 0
	int 16h
	
	; write out inputted number, move inputted number to bh
	mov ah, 2
	mov dl, al
	mov bh, al
	int 21h
	
	; line break
	mov dl, 10
	int 21h
	
	; write out msg3
	mov ah, 9
	mov dx, offset msg3
	int 21h
	
	; input number
	mov ah, 0
	int 16h
	
	; write out inputted number, move inputted number to cl
	mov ah, 2
	mov dl, al
	mov cl, al
	int 21h
	
	; line break
	mov dl, 10
	int 21h
	
	; move inputted numbers into range
	sub bl, 48
	sub bh, 48
	sub cl, 48
	
	; multipy bl with bh, add and substract shift from bl and bh
	mov al, bl
	mul bh
	mov bl, al
	mov bh, al
	add bl, cl
	sub bh, cl
	
	; move results into range
	add al, 48
	add bl, 48
	add bh, 48
	
	; write out result
	mov ah, 2
	mov dl, al
	int 21h
	
	; line break
	mov dl, 10
	int 21h
	
	; write out shift
	mov dl, bl
	int 21h
	
	; line break
	mov dl, 10
	int 21h
	
	; write out shift
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

