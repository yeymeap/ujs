
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
	mov cl, al
	int 21h
	
	mov dl, 10
	int 21h
	
	mov ah, 9
	mov dx, offset msg3
	int 21h
	
	mov ah, 2
	
	;add bl, cl
	;mov dl, bl ; add
	;sub dl, 48
	
	sub bl, cl
	mov dl, bl ; sub
	add dl, 48

	int 21h
	
	

Program_Vege:
	mov	ax, 4c00h
	int	21h

msg1 db "Bemeno szamok osszeadasa/kivonasa", 13, 10, "Elso szam: $"
msg2 db "Masodik szam: $"
msg3 db "Eredmeny: $"

Code	Ends

Data	Segment

Data	Ends

Stack	Segment

Stack	Ends
	End	Start

