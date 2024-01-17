˚
ID:\Real-Estate\RealEstate.Application\ApplicationServiceRegistrationDI.cs
	namespace 	

RealEstate
 
. 
Application  
{ 
public 

static 
class ,
 ApplicationServiceRegistrationDI 8
{ 
public 
static 
void "
AddApplicationServices 1
(1 2
this2 6
IServiceCollection7 I
servicesJ R
)R S
{		 	
services

 
.

 

AddMediatR

 
( 
cfg 
=> 
cfg 
. (
RegisterServicesFromAssembly ;
(; <
Assembly  
.  ! 
GetExecutingAssembly! 5
(5 6
)6 7
)7 8
) 
; 
} 	
} 
} ﬂ
HD:\Real-Estate\RealEstate.Application\Contracts\Identity\IAuthService.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
	Contracts! *
.* +
Identity+ 3
{ 
public 
	interface 
IAuthService 
{ 
Task 
< 
( 
int 
, 
string 
) 
> 
Registeration #
(# $
RegistrationModel$ 5
model6 ;
); <
;< =
Task		 
<		 
(		 
int		 
,		 
string		 
)		 
>		 
Login		 
(		 

LoginModel		 &
model		' ,
)		, -
;		- .
Task

 
<

 
(

 
int

 
,

 
string

 
)

 
>

 
ConfirmEmail

 "
(

" #
string

# )
email

* /
,

/ 0
string

1 7
token

8 =
)

= >
;

> ?
Task 
< 
( 
int 
, 
string 
) 
> 
ForgotPassword $
($ %
string% +
email, 1
)1 2
;2 3
Task 
< 
( 
int 
, 
string 
) 
> %
ResetPasswordConfirmation /
(/ 0
ResetPasswordModel0 B
modelC H
)H I
;I J
Task 
< 
( 
int 
, 
string 
) 
> 

DeleteUser  
(  !
string! '
email( -
)- .
;. /
} 
} Ø
QD:\Real-Estate\RealEstate.Application\Contracts\Interfaces\ICurrentUserService.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
	Contracts! *
.* +

Interfaces+ 5
{ 
public 
	interface 
ICurrentUserService %
{ 
string 
UserId	 
{ 
get 
; 
} 
ClaimsPrincipal %
GetCurrentClaimsPrincipal +
(+ ,
), -
;- .
string		 
GetCurrentUserId			 
(		 
)		 
;		 
}

 
} Ä
gD:\Real-Estate\RealEstate.Application\Features\Addresses\Commands\CreateAddress\CreateAddressCommand.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
	Addresses* 3
.3 4
Commands4 <
.< =
CreateAddress= J
{ 
public 

class  
CreateAddressCommand %
:& '
IRequest( 0
<0 1(
CreateAddressCommandResponse1 M
>M N
{ 
public 
string 
Url 
{ 
get 
;  
set! $
;$ %
}& '
=( )
default* 1
!1 2
;2 3
public 
string 
AddressName !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
default2 9
!9 :
;: ;
}		 
}

 ö!
nD:\Real-Estate\RealEstate.Application\Features\Addresses\Commands\CreateAddress\CreateAddressCommandHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
	Addresses* 3
.3 4
Commands4 <
.< =
CreateAddress= J
{ 
public 

class '
CreateAddressCommandHandler ,
: 
IRequestHandler 
<  
CreateAddressCommand *
,* +(
CreateAddressCommandResponse, H
>H I
{		 
private

 
readonly

 
IAddressRepository

 +

repository

, 6
;

6 7
public '
CreateAddressCommandHandler *
(* +
IAddressRepository+ =

repository> H
)H I
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< (
CreateAddressCommandResponse 6
>6 7
Handle8 >
(> ? 
CreateAddressCommand? S
requestT [
,[ \
CancellationToken] n
cancellationToken	o Ä
)
Ä Å
{ 	
var 
	validator 
= 
new )
CreateAddressCommandValidator  =
(= >
)> ?
;? @
var 
validatorResult 
=  !
await" '
	validator( 1
.1 2
ValidateAsync2 ?
(? @
request@ G
,G H
cancellationTokenI Z
)Z [
;[ \
if 
( 
! 
validatorResult  
.  !
IsValid! (
)( )
{ 
return 
new (
CreateAddressCommandResponse 7
{ 
Success 
= 
false #
,# $
ValidationErrors $
=% &
validatorResult' 6
.6 7
Errors7 =
.= >
Select> D
(D E
eE F
=>G I
eJ K
.K L
ErrorMessageL X
)X Y
.Y Z
ToListZ `
(` a
)a b
} 
; 
} 
var   
address   
=   
Address   !
.  ! "
Create  " (
(  ( )
request  ) 0
.  0 1
Url  1 4
,  4 5
request  6 =
.  = >
AddressName  > I
)  I J
;  J K
if!! 
(!! 
!!! 
address!! 
.!! 
	IsSuccess!! "
)!!" #
{"" 
return## 
new## (
CreateAddressCommandResponse## 7
{$$ 
Success%% 
=%% 
false%% #
,%%# $
ValidationErrors&& $
=&&% &
new&&' *
List&&+ /
<&&/ 0
string&&0 6
>&&6 7
(&&7 8
)&&8 9
{&&: ;
address&&< C
.&&C D
Error&&D I
}&&J K
}'' 
;'' 
}(( 
await** 

repository** 
.** 
AddAsync** %
(**% &
address**& -
.**- .
Value**. 3
)**3 4
;**4 5
return,, 
new,, (
CreateAddressCommandResponse,, 3
{-- 
Success.. 
=.. 
true.. 
,.. 
Address// 
=// 
new// 
CreateAddressDto// .
{00 
Id11 
=11 
address11  
.11  !
Value11! &
.11& '
Id11' )
,11) *
Url22 
=22 
address22 !
.22! "
Value22" '
.22' (
Url22( +
,22+ ,
AddressName33 
=33  !
address33" )
.33) *
Value33* /
.33/ 0
AddressName330 ;
}44 
}55 
;55 
}66 	
}77 
}88 
oD:\Real-Estate\RealEstate.Application\Features\Addresses\Commands\CreateAddress\CreateAddressCommandResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
	Addresses* 3
.3 4
Commands4 <
.< =
CreateAddress= J
{ 
public 

class (
CreateAddressCommandResponse -
:. /
BaseResponse0 <
{ 
public (
CreateAddressCommandResponse +
(+ ,
), -
:. /
base0 4
(4 5
)5 6
{7 8
}9 :
public		 
CreateAddressDto		 
Address		  '
{		( )
get		* -
;		- .
set		/ 2
;		2 3
}		4 5
}

 
} ö
pD:\Real-Estate\RealEstate.Application\Features\Addresses\Commands\CreateAddress\CreateAddressCommandValidator.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
	Addresses* 3
.3 4
Commands4 <
.< =
CreateAddress= J
{ 
public 

class )
CreateAddressCommandValidator .
:/ 0
AbstractValidator1 B
<B C 
CreateAddressCommandC W
>W X
{ 
public )
CreateAddressCommandValidator ,
(, -
)- .
{ 	
RuleFor		 
(		 
p		 
=>		 
p		 
.		 
AddressName		 &
)		& '
.

 
NotEmpty

 
(

 
)

 
.

 
WithMessage

 '
(

' (
$str

( E
)

E F
. 
NotNull 
( 
) 
. 
MaximumLength 
( 
$num "
)" #
.# $
WithMessage$ /
(/ 0
$str0 `
)` a
;a b
RuleFor 
( 
p 
=> 
p 
. 
Url 
) 
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
. 
MaximumLength 
( 
$num "
)" #
.# $
WithMessage$ /
(/ 0
$str0 `
)` a
;a b
} 	
} 
} π
cD:\Real-Estate\RealEstate.Application\Features\Addresses\Commands\CreateAddress\CreateAddressDto.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
	Addresses* 3
.3 4
Commands4 <
.< =
CreateAddress= J
{ 
public 

class 
CreateAddressDto !
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
string 
? 
Url 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
? 
AddressName "
{# $
get% (
;( )
set* -
;- .
}/ 0
} 
}		 ÿ
fD:\Real-Estate\RealEstate.Application\Features\Addresses\Commands\DeleteAddres\DeleteAddressCommand.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
	Addresses* 3
.3 4
Commands4 <
.< =
DeleteAddres= I
{ 
public 

class  
DeleteAddressCommand %
:& '
IRequest( 0
<0 1(
DeleteAddressCommandResponse1 M
>M N
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
} 
}		 ª
mD:\Real-Estate\RealEstate.Application\Features\Addresses\Commands\DeleteAddres\DeleteAddressCommandHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
	Addresses* 3
.3 4
Commands4 <
.< =
DeleteAddres= I
{ 
public 

class '
DeleteAddressCommandHandler ,
:- .
IRequestHandler/ >
<> ? 
DeleteAddressCommand? S
,S T(
DeleteAddressCommandResponseU q
>q r
{ 
private 
readonly 
IAddressRepository +

repository, 6
;6 7
public

 '
DeleteAddressCommandHandler

 *
(

* +
IAddressRepository

+ =

repository

> H
)

H I
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< (
DeleteAddressCommandResponse 6
>6 7
Handle8 >
(> ? 
DeleteAddressCommand? S
requestT [
,[ \
CancellationToken] n
cancellationToken	o Ä
)
Ä Å
{ 	
var 
result 
= 
await 

repository )
.) *
DeleteAsync* 5
(5 6
request6 =
.= >
Id> @
)@ A
;A B
if 
( 
! 
result 
. 
	IsSuccess !
)! "
{ 
return 
new (
DeleteAddressCommandResponse 7
{ 
Success 
= 
false #
,# $
ValidationErrors $
=% &
new' *
List+ /
</ 0
string0 6
>6 7
{8 9
result: @
.@ A
ErrorA F
}G H
} 
; 
} 
return 
new (
DeleteAddressCommandResponse 3
{ 
Success 
= 
true 
} 
; 
} 	
}   
}!! ê
nD:\Real-Estate\RealEstate.Application\Features\Addresses\Commands\DeleteAddres\DeleteAddressCommandResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
	Addresses* 3
.3 4
Commands4 <
.< =
DeleteAddres= I
{ 
public 

class (
DeleteAddressCommandResponse -
:. /
BaseResponse0 <
{ 
} 
} î	
gD:\Real-Estate\RealEstate.Application\Features\Addresses\Commands\UpdateAddress\UpdateAddressCommand.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
	Addresses* 3
.3 4
Commands4 <
.< =
UpdateAddress= J
{ 
public 

class  
UpdateAddressCommand %
:& '
IRequest( 0
<0 1(
UpdateAddressCommandResponse1 M
>M N
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
string 
Url 
{ 
get 
;  
set! $
;$ %
}& '
=( )
default* 1
!1 2
;2 3
public		 
string		 
AddressName		 !
{		" #
get		$ '
;		' (
set		) ,
;		, -
}		. /
=		0 1
default		2 9
!		9 :
;		: ;
}

 
} ú(
nD:\Real-Estate\RealEstate.Application\Features\Addresses\Commands\UpdateAddress\UpdateAddressCommandHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
	Addresses* 3
.3 4
Commands4 <
.< =
UpdateAddress= J
{ 
public 

class '
UpdateAddressCommandHandler ,
:- .
IRequestHandler/ >
<> ? 
UpdateAddressCommand? S
,S T(
UpdateAddressCommandResponseU q
>q r
{ 
private 
readonly 
IAddressRepository +

repository, 6
;6 7
public

 '
UpdateAddressCommandHandler

 *
(

* +
IAddressRepository

+ =

repository

> H
)

H I
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< (
UpdateAddressCommandResponse 6
>6 7
Handle8 >
(> ? 
UpdateAddressCommand? S
requestT [
,[ \
CancellationToken] n
cancellationToken	o Ä
)
Ä Å
{ 	
var 
address 
= 
await 

repository  *
.* +
FindByIdAsync+ 8
(8 9
request9 @
.@ A
IdA C
)C D
;D E
var 
	validator 
= 
new )
UpdateAddressCommandValidator  =
(= >
)> ?
;? @
var 
validatorResult 
=  !
await" '
	validator( 1
.1 2
ValidateAsync2 ?
(? @
request@ G
,G H
cancellationTokenI Z
)Z [
;[ \
if 
( 
! 
validatorResult  
.  !
IsValid! (
)( )
{ 
return 
new (
UpdateAddressCommandResponse 7
{ 
Success 
= 
false #
,# $
ValidationErrors $
=% &
validatorResult' 6
.6 7
Errors7 =
.= >
Select> D
(D E
eE F
=>G I
eJ K
.K L
ErrorMessageL X
)X Y
.Y Z
ToListZ `
(` a
)a b
} 
; 
} 
if 
( 
! 
address 
. 
	IsSuccess "
)" #
{ 
return   
new   (
UpdateAddressCommandResponse   7
{!! 
Success"" 
="" 
false"" #
,""# $
ValidationErrors## $
=##% &
new##' *
List##+ /
<##/ 0
string##0 6
>##6 7
(##7 8
)##8 9
{##: ;
address##< C
.##C D
Error##D I
}##J K
}$$ 
;$$ 
}%% 
address'' 
.'' 
Value'' 
.'' 
AttachAddressName'' +
(''+ ,
request'', 3
.''3 4
AddressName''4 ?
)''? @
;''@ A
address(( 
.(( 
Value(( 
.(( 
	AttachUrl(( #
(((# $
request(($ +
.((+ ,
Url((, /
)((/ 0
;((0 1
var)) 
updatedAddress)) 
=))  
await))! &

repository))' 1
.))1 2
UpdateAsync))2 =
())= >
address))> E
.))E F
Value))F K
)))K L
;))L M
if++ 
(++ 
!++ 
updatedAddress++ 
.++ 
	IsSuccess++ (
)++( )
{,, 
return-- 
new-- (
UpdateAddressCommandResponse-- 7
{.. 
Success// 
=// 
false// #
,//# $
ValidationErrors00 $
=00% &
new00' *
List00+ /
<00/ 0
string000 6
>006 7
(007 8
)008 9
{00: ;
updatedAddress00< J
.00J K
Error00K P
}00Q R
}11 
;11 
}22 
return44 
new44 (
UpdateAddressCommandResponse44 3
{55 
Success66 
=66 
true66 
,66 
Address77 
=77 
new77 
UpdateAddressDto77 .
{88 
Url99 
=99 
updatedAddress99 (
.99( )
Value99) .
.99. /
Url99/ 2
,992 3
AddressName:: 
=::  !
updatedAddress::" 0
.::0 1
Value::1 6
.::6 7
AddressName::7 B
};; 
}<< 
;<< 
}== 	
}>> 
}?? 
oD:\Real-Estate\RealEstate.Application\Features\Addresses\Commands\UpdateAddress\UpdateAddressCommandResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
	Addresses* 3
.3 4
Commands4 <
.< =
UpdateAddress= J
{ 
public 
class (
UpdateAddressCommandResponse *
:+ ,
BaseResponse- 9
{ 
public (
UpdateAddressCommandResponse +
(+ ,
), -
:. /
base0 4
(4 5
)5 6
{ 	
}		 	
public 
UpdateAddressDto 
Address  '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
} 
} ˝
pD:\Real-Estate\RealEstate.Application\Features\Addresses\Commands\UpdateAddress\UpdateAddressCommandValidator.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
	Addresses* 3
.3 4
Commands4 <
.< =
UpdateAddress= J
{ 
public 

class )
UpdateAddressCommandValidator .
:/ 0
AbstractValidator1 B
<B C 
UpdateAddressCommandC W
>W X
{ 
public )
UpdateAddressCommandValidator ,
(, -
)- .
{ 	
RuleFor		 
(		 
p		 
=>		 
p		 
.		 
Id		 
)		 
.

 
NotEmpty

 
(

 
)

 
.

 
WithMessage

 '
(

' (
$str

( E
)

E F
. 
NotNull 
( 
) 
. 
NotEqual 
( 
Guid 
. 
Empty $
)$ %
;% &
RuleFor 
( 
p 
=> 
p 
. 
AddressName &
)& '
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
. 
MaximumLength 
( 
$num "
)" #
. 
WithMessage 
( 
$str M
)M N
;N O
RuleFor 
( 
p 
=> 
p 
. 
Url 
) 
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
. 
MaximumLength 
( 
$num "
)" #
. 
WithMessage 
( 
$str M
)M N
;N O
} 	
} 
} •
cD:\Real-Estate\RealEstate.Application\Features\Addresses\Commands\UpdateAddress\UpdateAddressDto.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
	Addresses* 3
.3 4
Commands4 <
.< =
UpdateAddress= J
{ 
public 

class 
UpdateAddressDto !
{ 
public 
string 
? 
Url 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
? 
AddressName "
{# $
get% (
;( )
set* -
;- .
}/ 0
} 
} Ÿ
ND:\Real-Estate\RealEstate.Application\Features\Addresses\Queries\AddressDto.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
	Addresses* 3
.3 4
Queries4 ;
{ 
public 

class 

AddressDto 
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
string 
Url 
{ 
get 
;  
set! $
;$ %
}& '
=( )
default* 1
!1 2
;2 3
public 
string 
AddressName !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
default2 9
!9 :
;: ;
} 
}		 ±
_D:\Real-Estate\RealEstate.Application\Features\Addresses\Queries\GetAll\GetAllAddressesQuery.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
	Addresses* 3
.3 4
Queries4 ;
.; <
GetAll< B
{ 
public 

class  
GetAllAddressesQuery %
:& '
IRequest( 0
<0 1#
GetAllAddressesResponse1 H
>H I
{ 
} 
} ˝
fD:\Real-Estate\RealEstate.Application\Features\Addresses\Queries\GetAll\GetAllAddressesQueryHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
	Addresses* 3
.3 4
Queries4 ;
.; <
GetAll< B
{ 
public 

class '
GetAllAddressesQueryHandler ,
:- .
IRequestHandler/ >
<> ? 
GetAllAddressesQuery? S
,S T#
GetAllAddressesResponseU l
>l m
{ 
private 
readonly 
IAddressRepository +

repository, 6
;6 7
public

 '
GetAllAddressesQueryHandler

 *
(

* +
IAddressRepository

+ =

repository

> H
)

H I
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< #
GetAllAddressesResponse 1
>1 2
Handle3 9
(9 : 
GetAllAddressesQuery: N
requestO V
,V W
CancellationTokenX i
cancellationTokenj {
){ |
{ 	#
GetAllAddressesResponse #
response$ ,
=- .
new/ 2
(2 3
)3 4
;4 5
var 
result 
= 
await 

repository )
.) *
GetAllAsync* 5
(5 6
)6 7
;7 8
if 
( 
result 
. 
	IsSuccess 
)  
{ 
response 
. 
	Addresses "
=# $
result% +
.+ ,
Value, 1
.1 2
Select2 8
(8 9
address9 @
=>A C
newD G

AddressDtoH R
{ 
Id 
= 
address  
.  !
Id! #
,# $
Url 
= 
address !
.! "
Url" %
,% &
AddressName 
=  !
address" )
.) *
AddressName* 5
} 
) 
. 
ToList 
( 
) 
; 
} 
return 
response 
; 
} 	
} 
}   †
bD:\Real-Estate\RealEstate.Application\Features\Addresses\Queries\GetAll\GetAllAddressesResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
	Addresses* 3
.3 4
Queries4 ;
.; <
GetAll< B
{ 
public 

class #
GetAllAddressesResponse (
{ 
public 
List 
< 

AddressDto 
> 
	Addresses  )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
} 
} ÷
_D:\Real-Estate\RealEstate.Application\Features\Addresses\Queries\GetById\GetByIdAddressQuery.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
	Addresses* 3
.3 4
Queries4 ;
.; <
GetById< C
{ 
public 

record 
GetByIdAddressQuery %
(% &
Guid& *
Id+ -
)- .
:/ 0
IRequest1 9
<9 :

AddressDto: D
>D E
;E F
} ì
fD:\Real-Estate\RealEstate.Application\Features\Addresses\Queries\GetById\GetByIdAddressQueryHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
	Addresses* 3
.3 4
Queries4 ;
.; <
GetById< C
{ 
public 

class &
GetByIdAddressQueryHandler +
:, -
IRequestHandler. =
<= >
GetByIdAddressQuery> Q
,Q R

AddressDtoS ]
>] ^
{ 
private 
readonly 
IAddressRepository +

repository, 6
;6 7
public

 &
GetByIdAddressQueryHandler

 )
(

) *
IAddressRepository

* <

repository

= G
)

G H
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< 

AddressDto $
>$ %
Handle& ,
(, -
GetByIdAddressQuery- @
requestA H
,H I
CancellationTokenJ [
cancellationToken\ m
)m n
{ 	
var 
address 
= 
await 

repository  *
.* +
FindByIdAsync+ 8
(8 9
request9 @
.@ A
IdA C
)C D
;D E
if 
( 
address 
. 
	IsSuccess  
)  !
{ 
return 
new 

AddressDto %
{ 
Id 
= 
address  
.  !
Value! &
.& '
Id' )
,) *
Url 
= 
address !
.! "
Value" '
.' (
Url( +
,+ ,
AddressName 
=  !
address" )
.) *
Value* /
./ 0
AddressName0 ;
} 
; 
} 
return 
new 

AddressDto !
(! "
)" #
;# $
} 	
} 
} ≥
lD:\Real-Estate\RealEstate.Application\Features\Apartments\Commands\CreateApartment\CreateApartmentCommand.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

Apartments* 4
.4 5
Commands5 =
.= >
CreateApartament> N
{ 
public 

class "
CreateApartmentCommand '
:( )
IRequest* 2
<2 3*
CreateApartmentCommandResponse3 Q
>Q R
{ 
public 
string 
UserId 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
default- 4
!4 5
;5 6
public 
string 
	TitlePost 
{  !
get" %
;% &
set' *
;* +
}, -
=. /
default0 7
!7 8
;8 9
public		 
double		 
Price		 
{		 
get		 !
;		! "
set		# &
;		& '
}		( )
=		* +
default		, 3
!		3 4
;		4 5
public

 
Guid

 
	AddressId

 
{

 
get

  #
;

# $
set

% (
;

( )
}

* +
=

, -
default

. 5
!

5 6
;

6 7
public 
bool 
	OfferType 
{ 
get  #
;# $
set% (
;( )
}* +
=, -
default. 5
!5 6
;6 7
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
default2 9
!9 :
;: ;
public 
int 
	RoomCount 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
default- 4
!4 5
;5 6
public 
int 
Comfort 
{ 
get  
;  !
set" %
;% &
}' (
=) *
default+ 2
!2 3
;3 4
public 
int 
Floor 
{ 
get 
; 
set  #
;# $
}% &
=' (
default) 0
!0 1
;1 2
public 
double 
UsefulSurface #
{$ %
get& )
;) *
set+ .
;. /
}0 1
=2 3
default4 ;
!; <
;< =
public 
int 
	BuildYear 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
default- 4
!4 5
;5 6
public 
Guid 
PartitioningId "
{# $
get% (
;( )
set* -
;- .
}/ 0
=1 2
default3 :
!: ;
;; <
} 
} §3
sD:\Real-Estate\RealEstate.Application\Features\Apartments\Commands\CreateApartment\CreateApartmentCommandHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

Apartments* 4
.4 5
Commands5 =
.= >
CreateApartament> N
{ 
public 

class )
CreateApartmentCommandHandler .
:/ 0
IRequestHandler1 @
<@ A"
CreateApartmentCommandA W
,W X*
CreateApartmentCommandResponseY w
>w x
{ 
private		 
readonly		  
IApartmentRepository		 -

repository		. 8
;		8 9
public )
CreateApartmentCommandHandler ,
(, - 
IApartmentRepository- A

repositoryB L
)L M
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< *
CreateApartmentCommandResponse 8
>8 9
Handle: @
(@ A"
CreateApartmentCommandA W
requestX _
,_ `
CancellationTokena r
cancellationToken	s Ñ
)
Ñ Ö
{ 	
var 
	validator 
= 
new +
CreateApartmentCommandValidator  ?
(? @
)@ A
;A B
var 
validationResult  
=! "
await# (
	validator) 2
.2 3
ValidateAsync3 @
(@ A
requestA H
,H I
cancellationTokenJ [
)[ \
;\ ]
if 
( 
! 
validationResult !
.! "
IsValid" )
)) *
{ 
return 
new *
CreateApartmentCommandResponse 9
{ 
Success 
= 
false #
,# $
ValidationErrors $
=% &
validationResult' 7
.7 8
Errors8 >
.> ?
Select? E
(E F
eF G
=>H J
eK L
.L M
ErrorMessageM Y
)Y Z
.Z [
ToList[ a
(a b
)b c
} 
; 
} 
var 
	apartment 
= 
	Apartment %
.% &
Create& ,
(, -
request- 4
.4 5
UserId5 ;
,; <
request= D
.D E
	TitlePostE N
,N O
requestP W
.W X
PriceX ]
,] ^
request^ e
.e f
	AddressIdf o
,o p
requestq x
.x y
	OfferType	y Ç
,
Ç É
request
Ñ ã
.
ã å
Description
å ó
,
ó ò
request 
. 
	RoomCount !
,! "
request# *
.* +
Comfort+ 2
,2 3
request4 ;
.; <
Floor< A
,A B
requestC J
.J K
UsefulSurfaceK X
,X Y
requestZ a
.a b
	BuildYearb k
,k l
requestm t
.t u
PartitioningId	u É
)
É Ñ
;
Ñ Ö
if!! 
(!! 
!!! 
	apartment!! 
.!! 
	IsSuccess!! $
)!!$ %
{"" 
return## 
new## *
CreateApartmentCommandResponse## 9
{$$ 
Success%% 
=%% 
false%% #
,%%# $
ValidationErrors&& $
=&&% &
new&&' *
List&&+ /
<&&/ 0
string&&0 6
>&&6 7
(&&7 8
)&&8 9
{&&: ;
	apartment&&< E
.&&E F
Error&&F K
}&&L M
}'' 
;'' 
}(( 
await** 

repository** 
.** 
AddAsync** %
(**% &
	apartment**& /
.**/ 0
Value**0 5
)**5 6
;**6 7
return,, 
new,, *
CreateApartmentCommandResponse,, 5
{-- 
Success.. 
=.. 
true.. 
,.. 
	Apartment// 
=// 
new// 
CreateApartmentDTO//  2
{00 

BasePostId11 
=11  
	apartment11! *
.11* +
Value11+ 0
.110 1

BasePostId111 ;
,11; <
UserId22 
=22 
	apartment22 &
.22& '
Value22' ,
.22, -
UserId22- 3
,223 4
	TitlePost33 
=33 
	apartment33  )
.33) *
Value33* /
.33/ 0
	TitlePost330 9
,339 :
Price44 
=44 
	apartment44 %
.44% &
Value44& +
.44+ ,
Price44, 1
,441 2
	AddressId55 
=55 
	apartment55  )
.55) *
Value55* /
.55/ 0
	AddressId550 9
,559 :
	OfferType66 
=66 
	apartment66  )
.66) *
Value66* /
.66/ 0
	OfferType660 9
,669 :
Description77 
=77  !
	apartment77" +
.77+ ,
Value77, 1
.771 2
Description772 =
,77= >
	RoomCount88 
=88 
	apartment88  )
.88) *
Value88* /
.88/ 0
	RoomCount880 9
,889 :
Comfort99 
=99 
	apartment99 '
.99' (
Value99( -
.99- .
Comfort99. 5
,995 6
Floor:: 
=:: 
	apartment:: %
.::% &
Value::& +
.::+ ,
Floor::, 1
,::1 2
UsefulSurface;; !
=;;" #
	apartment;;$ -
.;;- .
Value;;. 3
.;;3 4
UsefulSurface;;4 A
,;;A B
	BuildYear<< 
=<< 
	apartment<<  )
.<<) *
Value<<* /
.<</ 0
	BuildYear<<0 9
,<<9 :
PartitioningId== "
===# $
	apartment==% .
.==. /
Value==/ 4
.==4 5
PartitioningId==5 C
}>> 
}?? 
;?? 
}@@ 	
}AA 
}BB Å
tD:\Real-Estate\RealEstate.Application\Features\Apartments\Commands\CreateApartment\CreateApartmentCommandResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

Apartments* 4
.4 5
Commands5 =
.= >
CreateApartament> N
{ 
public 

class *
CreateApartmentCommandResponse /
:0 1
BaseResponse2 >
{ 
public *
CreateApartmentCommandResponse -
(- .
). /
:0 1
base2 6
(6 7
)7 8
{ 	
}		 	
public 
CreateApartmentDTO !
	Apartment" +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
} 
} …3
uD:\Real-Estate\RealEstate.Application\Features\Apartments\Commands\CreateApartment\CreateApartmentCommandValidator.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

Apartments* 4
.4 5
Commands5 =
.= >
CreateApartament> N
{ 
public 

class +
CreateApartmentCommandValidator 0
:1 2
AbstractValidator3 D
<D E"
CreateApartmentCommandE [
>[ \
{ 
public +
CreateApartmentCommandValidator .
(. /
)/ 0
{ 	
RuleFor		 
(		 
p		 
=>		 
p		 
.		 
UserId		 !
)		! "
.

 
NotEmpty

 
(

 
)

 
.

 
WithMessage

 '
(

' (
$str

( E
)

E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
	TitlePost $
)$ %
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
Price  
)  !
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
. 
GreaterThan 
( 
$num 
) 
.  
WithMessage  +
(+ ,
$str, T
)T U
;U V
RuleFor 
( 
p 
=> 
p 
. 
	AddressId $
)$ %
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
	OfferType $
)$ %
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
Description &
)& '
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
.   
NotNull   
(   
)   
.!! 
MaximumLength!! 
(!! 
$num!! #
)!!# $
.!!$ %
WithMessage!!% 0
(!!0 1
$str!!1 b
)!!b c
;!!c d
RuleFor## 
(## 
p## 
=>## 
p## 
.## 
	RoomCount## $
)##$ %
.$$ 
NotEmpty$$ 
($$ 
)$$ 
.$$ 
WithMessage$$ '
($$' (
$str$$( E
)$$E F
.%% 
NotNull%% 
(%% 
)%% 
.&& 
GreaterThan&& 
(&& 
$num&& 
)&& 
.&&  
WithMessage&&  +
(&&+ ,
$str&&, T
)&&T U
;&&U V
RuleFor(( 
((( 
p(( 
=>(( 
p(( 
.(( 
Comfort(( "
)((" #
.)) 
NotEmpty)) 
()) 
))) 
.)) 
WithMessage)) '
())' (
$str))( E
)))E F
.** 
NotNull** 
(** 
)** 
.++ 
InclusiveBetween++ !
(++! "
$num++" #
,++# $
$num++% &
)++& '
.++' (
WithMessage++( 3
(++3 4
$str++4 ]
)++] ^
;++^ _
RuleFor-- 
(-- 
p-- 
=>-- 
p-- 
.-- 
Floor--  
)--  !
... 
NotEmpty.. 
(.. 
).. 
... 
WithMessage.. '
(..' (
$str..( E
)..E F
.// 
NotNull// 
(// 
)// 
.00 
GreaterThan00 
(00 
$num00 
)00 
.00  
WithMessage00  +
(00+ ,
$str00, T
)00T U
;00U V
RuleFor22 
(22 
p22 
=>22 
p22 
.22 
UsefulSurface22 (
)22( )
.33 
NotEmpty33 
(33 
)33 
.33 
WithMessage33 '
(33' (
$str33( E
)33E F
.44 
NotNull44 
(44 
)44 
.55 
GreaterThan55 
(55 
$num55 
)55 
.55  
WithMessage55  +
(55+ ,
$str55, T
)55T U
;55U V
RuleFor77 
(77 
p77 
=>77 
p77 
.77 
	BuildYear77 $
)77$ %
.88 
NotEmpty88 
(88 
)88 
.88 
WithMessage88 '
(88' (
$str88( E
)88E F
.99 
NotNull99 
(99 
)99 
.:: 
InclusiveBetween:: !
(::! "
$num::" &
,::& '
DateTime::( 0
.::0 1
Now::1 4
.::4 5
Year::5 9
+::: ;
$num::< =
)::= >
.;; 
WithMessage;; 
(;; 
$str;; T
);;T U
;;;U V
RuleFor== 
(== 
p== 
=>== 
p== 
.== 
PartitioningId== )
)==) *
.>> 
NotEmpty>> 
(>> 
)>> 
.>> 
WithMessage>> '
(>>' (
$str>>( E
)>>E F
.?? 
NotNull?? 
(?? 
)?? 
;?? 
}AA 	
}BB 
}CC —
hD:\Real-Estate\RealEstate.Application\Features\Apartments\Commands\CreateApartment\CreateApartmentDto.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

Apartments* 4
.4 5
Commands5 =
.= >
CreateApartament> N
{ 
public 

class 
CreateApartmentDTO #
{ 
public 
Guid 

BasePostId 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
UserId 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
default- 4
!4 5
;5 6
public 
string 
	TitlePost 
{  !
get" %
;% &
set' *
;* +
}, -
=. /
default0 7
!7 8
;8 9
public 
double 
Price 
{ 
get !
;! "
set# &
;& '
}( )
public		 
Guid		 
	AddressId		 
{		 
get		  #
;		# $
set		% (
;		( )
}		* +
public

 
bool

 
	OfferType

 
{

 
get

  #
;

# $
set

% (
;

( )
}

* +
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
default2 9
!9 :
;: ;
public 
int 
? 
	RoomCount 
{ 
get  #
;# $
set% (
;( )
}* +
public 
int 
? 
Comfort 
{ 
get !
;! "
set# &
;& '
}( )
public 
int 
? 
Floor 
{ 
get 
;  
set! $
;$ %
}& '
public 
double 
? 
UsefulSurface $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
int 
? 
	BuildYear 
{ 
get  #
;# $
set% (
;( )
}* +
public 
Guid 
PartitioningId "
{# $
get% (
;( )
set* -
;- .
}/ 0
} 
} Ÿ
eD:\Real-Estate\RealEstate.Application\Features\Apartments\Commands\DeleteApartment\DeleteApartment.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

Apartments* 4
.4 5
Commands5 =
.= >
DeleteApartment> M
{ 
public 

class 
DeleteApartment  
:! "
IRequest# +
<+ ,#
DeleteApartmentResponse, C
>C D
{ 
public 
Guid 

BasePostId 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
}		 ü
lD:\Real-Estate\RealEstate.Application\Features\Apartments\Commands\DeleteApartment\DeleteApartmentHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

Apartments* 4
.4 5
Commands5 =
.= >
DeleteApartment> M
{ 
public 

class "
DeleteApartmentHandler '
:( )
IRequestHandler* 9
<9 :
DeleteApartment: I
,I J#
DeleteApartmentResponseK b
>b c
{ 
private 
readonly  
IApartmentRepository -

repository. 8
;8 9
public

 "
DeleteApartmentHandler

 %
(

% & 
IApartmentRepository

& :

repository

; E
)

E F
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< #
DeleteApartmentResponse 1
>1 2
Handle3 9
(9 :
DeleteApartment: I
requestJ Q
,Q R
CancellationTokenS d
cancellationTokene v
)v w
{ 	
var 
result 
= 
await 

repository )
.) *
DeleteAsync* 5
(5 6
request6 =
.= >

BasePostId> H
)H I
;I J
if 
( 
! 
result 
. 
	IsSuccess !
)! "
{ 
return 
new #
DeleteApartmentResponse 2
{ 
Success 
= 
false #
,# $
ValidationErrors $
=% &
new' *
List+ /
</ 0
string0 6
>6 7
{8 9
result: @
.@ A
ErrorA F
}G H
} 
; 
} 
return 
new #
DeleteApartmentResponse .
{ 
Success 
= 
true 
} 
; 
} 	
}   
}!! é
mD:\Real-Estate\RealEstate.Application\Features\Apartments\Commands\DeleteApartment\DeleteApartmentResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

Apartments* 4
.4 5
Commands5 =
.= >
DeleteApartment> M
{ 
public 

class #
DeleteApartmentResponse (
:) *
BaseResponse+ 7
{ 
} 
} å
lD:\Real-Estate\RealEstate.Application\Features\Apartments\Commands\UpdateApartment\UpdateApartmentCommand.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

Apartments* 4
.4 5
Commands5 =
.= >
UpdateApartment> M
{ 
public 
class "
UpdateApartmentCommand $
:% &
IRequest' /
</ 0*
UpdateApartmentCommandResponse0 N
>N O
{ 
public 
Guid 

BasePostId 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
UserId 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
default- 4
!4 5
;5 6
public		 
string			 
	TitlePost		 
{		 
get		 
;		  
set		! $
;		$ %
}		& '
=		( )
default		* 1
!		1 2
;		2 3
public

 
double

	 
Price

 
{

 
get

 
;

 
set

  
;

  !
}

" #
=

$ %
default

& -
!

- .
;

. /
public 
Guid	 
	AddressId 
{ 
get 
; 
set "
;" #
}$ %
=& '
default( /
!/ 0
;0 1
public 
bool	 
	OfferType 
{ 
get 
; 
set "
;" #
}$ %
=& '
default( /
!/ 0
;0 1
public 
string	 
Description 
{ 
get !
;! "
set# &
;& '
}( )
=* +
default, 3
!3 4
;4 5
public 
int	 
	RoomCount 
{ 
get 
; 
set !
;! "
}# $
=% &
default' .
!. /
;/ 0
public 
int	 
Comfort 
{ 
get 
; 
set 
;  
}! "
=# $
default% ,
!, -
;- .
public 
int	 
Floor 
{ 
get 
; 
set 
; 
}  
=! "
default# *
!* +
;+ ,
public 
double	 
UsefulSurface 
{ 
get  #
;# $
set% (
;( )
}* +
=, -
default. 5
!5 6
;6 7
public 
int	 
	BuildYear 
{ 
get 
; 
set !
;! "
}# $
=% &
default' .
!. /
;/ 0
public 
Guid	 
PartitioningId 
{ 
get "
;" #
set$ '
;' (
}) *
} 
} îF
sD:\Real-Estate\RealEstate.Application\Features\Apartments\Commands\UpdateApartment\UpdateApartmentCommandHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

Apartments* 4
.4 5
Commands5 =
.= >
UpdateApartment> M
{ 
public 
class *
UpdateApartamentCommandHandler ,
:- .
IRequestHandler/ >
<> ?"
UpdateApartmentCommand? U
,U V*
UpdateApartmentCommandResponseW u
>u v
{ 
private		 	
readonly		
  
IApartmentRepository		 '

repository		( 2
;		2 3
public *
UpdateApartamentCommandHandler	 '
(' ( 
IApartmentRepository( <

repository= G
)G H
{ 
this 
. 

repository 
= 

repository 
;  
} 
public 
async	 
Task 
< *
UpdateApartmentCommandResponse 2
>2 3
Handle4 :
(: ;"
UpdateApartmentCommand; Q
requestR Y
,Y Z
CancellationToken[ l
cancellationTokenm ~
)~ 
{ 
var 
	apartment 
= 
await 

repository #
.# $
FindByIdAsync$ 1
(1 2
request2 9
.9 :

BasePostId: D
)D E
;E F
var 
	validator 
= 
new +
UpdateApartmentCommandValidator 6
(6 7
)7 8
;8 9
var 
validatorResult 
= 
await 
	validator (
.( )
ValidateAsync) 6
(6 7
request7 >
,> ?
cancellationToken@ Q
)Q R
;R S
if 
( 
! 
validatorResult 
. 
IsValid 
)  
{ 
return 

new *
UpdateApartmentCommandResponse -
{ 
Success 
= 
false 
, 
ValidationErrors 
= 
validatorResult '
.' (
Errors( .
.. /
Select/ 5
(5 6
e6 7
=>8 :
e; <
.< =
ErrorMessage= I
)I J
.J K
ToListK Q
(Q R
)R S
} 
; 
} 
if 
( 
! 
	apartment 
. 
	IsSuccess 
) 
{ 
return   

new   *
UpdateApartmentCommandResponse   -
{!! 
Success"" 
="" 
false"" 
,"" 
ValidationErrors## 
=## 
new## 
List##  
<##  !
string##! '
>##' (
(##( )
)##) *
{##+ ,
	apartment##- 6
.##6 7
Error##7 <
}##= >
}$$ 
;$$ 
}%% 
	apartment'' 
.'' 
Value'' 
.'' 
AttachRoomCount'' "
(''" #
request''# *
.''* +
	RoomCount''+ 4
)''4 5
;''5 6
	apartment(( 
.(( 
Value(( 
.(( 
AttachComfort((  
(((  !
request((! (
.((( )
Comfort(() 0
)((0 1
;((1 2
	apartment)) 
.)) 
Value)) 
.)) 
AttachFloor)) 
()) 
request)) &
.))& '
Floor))' ,
))), -
;))- .
	apartment** 
.** 
Value** 
.** 
AttachUsefulSurface** &
(**& '
request**' .
.**. /
UsefulSurface**/ <
)**< =
;**= >
	apartment++ 
.++ 
Value++ 
.++ 
AttachBuildYear++ "
(++" #
request++# *
.++* +
	BuildYear+++ 4
)++4 5
;++5 6
	apartment,, 
.,, 
Value,, 
.,,  
AttachPartitioningId,, '
(,,' (
request,,( /
.,,/ 0
PartitioningId,,0 >
),,> ?
;,,? @
	apartment-- 
.-- 
Value-- 
.-- 
AttachUserId-- 
(--  
request--  '
.--' (
UserId--( .
)--. /
;--/ 0
	apartment.. 
... 
Value.. 
... 
AttachTitlePost.. "
(.." #
request..# *
...* +
	TitlePost..+ 4
)..4 5
;..5 6
	apartment// 
.// 
Value// 
.// 
AttachPrice// 
(// 
request// &
.//& '
Price//' ,
)//, -
;//- .
	apartment00 
.00 
Value00 
.00 
AttachAddressId00 "
(00" #
request00# *
.00* +
	AddressId00+ 4
)004 5
;005 6
	apartment11 
.11 
Value11 
.11 
AttachOfferType11 "
(11" #
request11# *
.11* +
	OfferType11+ 4
)114 5
;115 6
	apartment22 
.22 
Value22 
.22 
AttachDescription22 $
(22$ %
request22% ,
.22, -
Description22- 8
)228 9
;229 :
var44 
updatedApartment44 
=44 
await44 

repository44  *
.44* +
UpdateAsync44+ 6
(446 7
	apartment447 @
.44@ A
Value44A F
)44F G
;44G H
if66 
(66 
!66 
updatedApartment66 
.66 
	IsSuccess66 "
)66" #
{77 
return88 

new88 *
UpdateApartmentCommandResponse88 -
{99 
Success:: 
=:: 
false:: 
,:: 
ValidationErrors;; 
=;; 
new;; 
List;;  
<;;  !
string;;! '
>;;' (
(;;( )
);;) *
{;;+ ,
updatedApartment;;- =
.;;= >
Error;;> C
};;D E
}<< 
;<< 
}== 
return?? 	
new??
 *
UpdateApartmentCommandResponse?? ,
{@@ 
SuccessAA 
=AA 
trueAA 
,AA 
	ApartmentBB 
=BB 
newBB 
UpdateApartmentDtoBB &
{CC 

BasePostIdDD 
=DD  
updatedApartmentDD! 1
.DD1 2
ValueDD2 7
.DD7 8

BasePostIdDD8 B
,DDB C
UserIdEE 
=EE 
updatedApartmentEE -
.EE- .
ValueEE. 3
.EE3 4
UserIdEE4 :
,EE: ;
	TitlePostFF 
=FF 
updatedApartmentFF !
.FF! "
ValueFF" '
.FF' (
	TitlePostFF( 1
,FF1 2
PriceGG 

=GG 
updatedApartmentGG 
.GG 
ValueGG #
.GG# $
PriceGG$ )
,GG) *
	AddressIdHH 
=HH 
updatedApartmentHH !
.HH! "
ValueHH" '
.HH' (
	AddressIdHH( 1
,HH1 2
	OfferTypeII 
=II 
updatedApartmentII !
.II! "
ValueII" '
.II' (
	OfferTypeII( 1
,II1 2
DescriptionJJ 
=JJ 
updatedApartmentJJ #
.JJ# $
ValueJJ$ )
.JJ) *
DescriptionJJ* 5
,JJ5 6
	RoomCountKK 
=KK 
updatedApartmentKK !
.KK! "
ValueKK" '
.KK' (
	RoomCountKK( 1
,KK1 2
ComfortLL 
=LL 
updatedApartmentLL 
.LL  
ValueLL  %
.LL% &
ComfortLL& -
,LL- .
FloorMM 

=MM 
updatedApartmentMM 
.MM 
ValueMM #
.MM# $
FloorMM$ )
,MM) *
UsefulSurfaceNN 
=NN 
updatedApartmentNN %
.NN% &
ValueNN& +
.NN+ ,
UsefulSurfaceNN, 9
,NN9 :
	BuildYearOO 
=OO 
updatedApartmentOO !
.OO! "
ValueOO" '
.OO' (
	BuildYearOO( 1
,OO1 2
PartitioningIdPP 
=PP 
updatedApartmentPP &
.PP& '
ValuePP' ,
.PP, -
PartitioningIdPP- ;
}QQ 
}RR 
;RR 
}TT 
}UU 
}WW Ä
tD:\Real-Estate\RealEstate.Application\Features\Apartments\Commands\UpdateApartment\UpdateApartmentCommandResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

Apartments* 4
.4 5
Commands5 =
.= >
UpdateApartment> M
{ 
public 
class *
UpdateApartmentCommandResponse ,
:- .
BaseResponse/ ;
{ 
public		 *
UpdateApartmentCommandResponse			 '
(		' (
)		( )
:		* +
base		, 0
(		0 1
)		1 2
{

 
} 
public 
UpdateApartmentDto	 
	Apartment %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
} 
} ©5
uD:\Real-Estate\RealEstate.Application\Features\Apartments\Commands\UpdateApartment\UpdateApartmentCommandValidator.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

Apartments* 4
.4 5
Commands5 =
.= >
UpdateApartment> M
{ 
public 
class +
UpdateApartmentCommandValidator -
:- .
AbstractValidator/ @
<@ A"
UpdateApartmentCommandA W
>W X
{ 
public +
UpdateApartmentCommandValidator	 (
(( )
)) *
{ 
RuleFor		 

(		
 
p		 
=>		 
p		 
.		 

BasePostId		 
)		 
.

 
NotEmpty

 
(

 
)

 
.

 
WithMessage

 
(

 
$str

 9
)

9 :
. 
NotNull 
( 
) 
; 
RuleFor 

(
 
p 
=> 
p 
. 
UserId 
) 
. 
NotEmpty 
( 
) 
. 
WithMessage 
( 
$str 9
)9 :
. 
NotNull 
( 
) 
; 
RuleFor 

(
 
p 
=> 
p 
. 
	TitlePost 
) 
. 
NotEmpty 
( 
) 
. 
WithMessage 
( 
$str 9
)9 :
. 
NotNull 
( 
) 
; 
RuleFor 

(
 
p 
=> 
p 
. 
Price 
) 
. 
NotEmpty 
( 
) 
. 
WithMessage 
( 
$str 9
)9 :
. 
NotNull 
( 
) 
. 
GreaterThan 
( 
$num 
) 
.  
WithMessage  +
(+ ,
$str, T
)T U
;U V
RuleFor 

(
 
p 
=> 
p 
. 
	AddressId 
) 
. 
NotEmpty 
( 
) 
. 
WithMessage 
( 
$str 9
)9 :
. 
NotNull 
( 
) 
; 
RuleFor 

(
 
p 
=> 
p 
. 
	OfferType 
) 
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
.   
NotNull   
(   
)   
;   
RuleFor"" 

(""
 
p"" 
=>"" 
p"" 
."" 
Description"" 
)"" 
.## 
NotEmpty## 
(## 
)## 
.## 
WithMessage## 
(## 
$str## 9
)##9 :
.$$ 
NotNull$$ 
($$ 
)$$ 
.%% 
MaximumLength%% 
(%% 
$num%% #
)%%# $
.%%$ %
WithMessage%%% 0
(%%0 1
$str%%1 b
)%%b c
;%%c d
RuleFor'' 

(''
 
p'' 
=>'' 
p'' 
.'' 
	RoomCount'' 
)'' 
.(( 
NotEmpty(( 
((( 
)(( 
.(( 
WithMessage(( 
((( 
$str(( 9
)((9 :
.)) 
NotNull)) 
()) 
))) 
.** 
GreaterThan** 
(** 
$num** 
)** 
;** 
RuleFor,, 

(,,
 
p,, 
=>,, 
p,, 
.,, 
Comfort,, 
),, 
.-- 
NotEmpty-- 
(-- 
)-- 
.-- 
WithMessage-- 
(-- 
$str-- 9
)--9 :
... 
NotNull.. 
(.. 
).. 
.// 
GreaterThan// 
(// 
$num// 
)// 
.// 
WithMessage// 
(//  
$str//  H
)//H I
;//I J
RuleFor11 

(11
 
p11 
=>11 
p11 
.11 
Floor11 
)11 
.22 
NotEmpty22 
(22 
)22 
.22 
WithMessage22 
(22 
$str22 9
)229 :
.33 
NotNull33 
(33 
)33 
.44 
GreaterThan44 
(44 
$num44 
)44 
.44 
WithMessage44 
(44  
$str44  H
)44H I
;44I J
RuleFor66 

(66
 
p66 
=>66 
p66 
.66 
UsefulSurface66 
)66  
.77 
NotEmpty77 
(77 
)77 
.77 
WithMessage77 
(77 
$str77 9
)779 :
.88 
NotNull88 
(88 
)88 
.99 
GreaterThan99 
(99 
$num99 
)99 
.99 
WithMessage99 
(99  
$str99  H
)99H I
;99I J
RuleFor;; 

(;;
 
p;; 
=>;; 
p;; 
.;; 
	BuildYear;; 
);; 
.<< 
NotEmpty<< 
(<< 
)<< 
.<< 
WithMessage<< 
(<< 
$str<< 9
)<<9 :
.== 
NotNull== 
(== 
)== 
.>> 
GreaterThan>> 
(>> 
$num>> 
)>> 
.>> 
WithMessage>> 
(>>  
$str>>  H
)>>H I
;>>I J
RuleFor@@ 

(@@
 
p@@ 
=>@@ 
p@@ 
.@@ 
PartitioningId@@  
)@@  !
.AA 
NotEmptyAA 
(AA 
)AA 
.AA 
WithMessageAA 
(AA 
$strAA 9
)AA9 :
.BB 
NotNullBB 
(BB 
)BB 
.CC 
NotEqualCC 
(CC 
GuidCC 
.CC 
EmptyCC 
)CC 
;CC 
}DD 
}EE 
}FF —
hD:\Real-Estate\RealEstate.Application\Features\Apartments\Commands\UpdateApartment\UpdateApartmentDto.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

Apartments* 4
.4 5
Commands5 =
.= >
UpdateApartament> N
{ 
public 
class 
UpdateApartmentDto  
{ 
public 
Guid 

BasePostId 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
UserId 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
default- 4
!4 5
;5 6
public 
string	 
	TitlePost 
{ 
get 
;  
set! $
;$ %
}& '
=( )
default* 1
!1 2
;2 3
public 
double	 
Price 
{ 
get 
; 
set  
;  !
}" #
public		 
Guid			 
	AddressId		 
{		 
get		 
;		 
set		 "
;		" #
}		$ %
public

 
bool

	 
	OfferType

 
{

 
get

 
;

 
set

 "
;

" #
}

$ %
public 
string	 
Description 
{ 
get !
;! "
set# &
;& '
}( )
=* +
default, 3
!3 4
;4 5
public 
int	 
? 
	RoomCount 
{ 
get 
; 
set "
;" #
}$ %
public 
int	 
? 
Comfort 
{ 
get 
; 
set  
;  !
}" #
public 
int	 
? 
Floor 
{ 
get 
; 
set 
; 
}  !
public 
double	 
? 
UsefulSurface 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
int	 
? 
	BuildYear 
{ 
get 
; 
set "
;" #
}$ %
public 
Guid	 
PartitioningId 
{ 
get "
;" #
set$ '
;' (
}) *
} 
} À
QD:\Real-Estate\RealEstate.Application\Features\Apartments\Queries\ApartmentDto.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

Apartments* 4
.4 5
Queries5 <
{ 
public 

class 
ApartmentDto 
{ 
public 
Guid 

BasePostId 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
UserId 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
default- 4
!4 5
;5 6
public 
string 
	TitlePost 
{  !
get" %
;% &
set' *
;* +
}, -
=. /
default0 7
!7 8
;8 9
public 
double 
Price 
{ 
get !
;! "
set# &
;& '
}( )
=* +
default, 3
!3 4
;4 5
public		 
Guid		 
	AddressId		 
{		 
get		  #
;		# $
set		% (
;		( )
}		* +
=		, -
default		. 5
!		5 6
;		6 7
public

 
bool

 
	OfferType

 
{

 
get

  #
;

# $
set

% (
;

( )
}

* +
=

, -
default

. 5
!

5 6
;

6 7
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
default2 9
!9 :
;: ;
public 
int 
	RoomCount 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
default- 4
!4 5
;5 6
public 
int 
Comfort 
{ 
get  
;  !
set" %
;% &
}' (
=) *
default+ 2
!2 3
;3 4
public 
int 
Floor 
{ 
get 
; 
set  #
;# $
}% &
=' (
default) 0
!0 1
;1 2
public 
double 
UsefulSurface #
{$ %
get& )
;) *
set+ .
;. /
}0 1
=2 3
default4 ;
!; <
;< =
public 
int 
	BuildYear 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
default- 4
!4 5
;5 6
public 
Guid 
PartitioningId "
{# $
get% (
;( )
set* -
;- .
}/ 0
} 
} ∂
aD:\Real-Estate\RealEstate.Application\Features\Apartments\Queries\GetAll\GetAllApartmentsQuery.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

Apartments* 4
.4 5
Queries5 <
.< =
GetAll= C
{ 
public 

class !
GetAllApartmentsQuery &
:' (
IRequest) 1
<1 2$
GetAllApartmentsResponse2 J
>J K
{ 
} 
} û
hD:\Real-Estate\RealEstate.Application\Features\Apartments\Queries\GetAll\GetAllApartmentsQueryHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

Apartments* 4
.4 5
Queries5 <
.< =
GetAll= C
{ 
public 

class (
GetAllApartmentsQueryHandler -
:. /
IRequestHandler0 ?
<? @!
GetAllApartmentsQuery@ U
,U V$
GetAllApartmentsResponseW o
>o p
{ 
private 
readonly  
IApartmentRepository -

repository. 8
;8 9
public

 (
GetAllApartmentsQueryHandler

 +
(

+ , 
IApartmentRepository

, @

repository

A K
)

K L
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< $
GetAllApartmentsResponse 2
>2 3
Handle4 :
(: ;!
GetAllApartmentsQuery; P
requestQ X
,X Y
CancellationTokenZ k
cancellationTokenl }
)} ~
{ 	$
GetAllApartmentsResponse $
response% -
=. /
new0 3
(3 4
)4 5
;5 6
var 
result 
= 
await 

repository )
.) *
GetAllAsync* 5
(5 6
)6 7
;7 8
if 
( 
result 
. 
	IsSuccess 
)  
{ 
response 
. 

Apartments #
=$ %
result& ,
., -
Value- 2
.2 3
Select3 9
(9 :
	apartment: C
=>D F
newG J
ApartmentDtoK W
{ 

BasePostId 
=  
	apartment! *
.* +

BasePostId+ 5
,5 6
UserId 
= 
	apartment &
.& '
UserId' -
,- .
	TitlePost 
= 
	apartment  )
.) *
	TitlePost* 3
,3 4
Price 
= 
	apartment %
.% &
Price& +
,+ ,
	AddressId 
= 
	apartment  )
.) *
	AddressId* 3
,3 4
	OfferType 
= 
	apartment  )
.) *
	OfferType* 3
,3 4
Description 
=  !
	apartment" +
.+ ,
Description, 7
,7 8
	RoomCount 
= 
	apartment  )
.) *
	RoomCount* 3
,3 4
Comfort   
=   
	apartment   '
.  ' (
Comfort  ( /
,  / 0
Floor!! 
=!! 
	apartment!! %
.!!% &
Floor!!& +
,!!+ ,
UsefulSurface"" !
=""" #
	apartment""$ -
.""- .
UsefulSurface"". ;
,""; <
	BuildYear## 
=## 
	apartment##  )
.##) *
	BuildYear##* 3
,##3 4
PartitioningId$$ "
=$$# $
	apartment$$% .
.$$. /
PartitioningId$$/ =
}%% 
)%% 
.%% 
ToList%% 
(%% 
)%% 
;%% 
}&& 
return'' 
response'' 
;'' 
}(( 	
})) 
}** ß
dD:\Real-Estate\RealEstate.Application\Features\Apartments\Queries\GetAll\GetAllApartmentsResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

Apartments* 4
.4 5
Queries5 <
.< =
GetAll= C
{ 
public 

class $
GetAllApartmentsResponse )
{ 
public 
List 
< 
ApartmentDto  
>  !

Apartments" ,
{- .
get/ 2
;2 3
set4 7
;7 8
}9 :
} 
} ﬁ
bD:\Real-Estate\RealEstate.Application\Features\Apartments\Queries\GetById\GetByIdApartmentQuery.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

Apartments* 4
.4 5
Queries5 <
.< =
GetById= D
{ 
public 

record !
GetByIdApartmentQuery '
(' (
Guid( ,
Id- /
)/ 0
:1 2
IRequest3 ;
<; <
ApartmentDto< H
>H I
;I J
} ë
iD:\Real-Estate\RealEstate.Application\Features\Apartments\Queries\GetById\GetByIdApartmentQueryHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

Apartments* 4
.4 5
Queries5 <
.< =
GetById= D
{ 
public 

class (
GetByIdApartmentQueryHandler -
:. /
IRequestHandler0 ?
<? @!
GetByIdApartmentQuery@ U
,U V
ApartmentDtoW c
>c d
{ 
private 
readonly  
IApartmentRepository -

repository. 8
;8 9
public

 (
GetByIdApartmentQueryHandler

 +
(

+ , 
IApartmentRepository

, @

repository

A K
)

K L
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< 
ApartmentDto &
>& '
Handle( .
(. /!
GetByIdApartmentQuery/ D
requestE L
,L M
CancellationTokenN _
cancellationToken` q
)q r
{ 	
var 
	apartment 
= 
await !

repository" ,
., -
FindByIdAsync- :
(: ;
request; B
.B C
IdC E
)E F
;F G
if 
( 
	apartment 
. 
	IsSuccess "
)" #
{ 
return 
new 
ApartmentDto '
{ 

BasePostId 
=  
	apartment! *
.* +
Value+ 0
.0 1

BasePostId1 ;
,; <
UserId 
= 
	apartment &
.& '
Value' ,
., -
UserId- 3
,3 4
	TitlePost 
= 
	apartment  )
.) *
Value* /
./ 0
	TitlePost0 9
,9 :
Price 
= 
	apartment %
.% &
Value& +
.+ ,
Price, 1
,1 2
	AddressId 
= 
	apartment  )
.) *
Value* /
./ 0
	AddressId0 9
,9 :
	OfferType 
= 
	apartment  )
.) *
Value* /
./ 0
	OfferType0 9
,9 :
Description 
=  !
	apartment" +
.+ ,
Value, 1
.1 2
Description2 =
,= >
	RoomCount 
= 
	apartment  )
.) *
Value* /
./ 0
	RoomCount0 9
,9 :
Comfort 
= 
	apartment '
.' (
Value( -
.- .
Comfort. 5
,5 6
Floor   
=   
	apartment   %
.  % &
Value  & +
.  + ,
Floor  , 1
,  1 2
UsefulSurface!! !
=!!" #
	apartment!!$ -
.!!- .
Value!!. 3
.!!3 4
UsefulSurface!!4 A
,!!A B
	BuildYear"" 
="" 
	apartment""  )
."") *
Value""* /
.""/ 0
	BuildYear""0 9
,""9 :
PartitioningId## "
=### $
	apartment##% .
.##. /
Value##/ 4
.##4 5
PartitioningId##5 C
}$$ 
;$$ 
}%% 
return&& 
new&& 
ApartmentDto&& #
(&&# $
)&&$ %
;&&% &
}'' 	
}(( 
})) ˝
iD:\Real-Estate\RealEstate.Application\Features\BasePosts\Commands\CreateBasePost\CreateBasePostCommand.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

Categories* 4
.4 5
Commands5 =
.= >
CreateBasePost> L
{ 
public 

class !
CreateBasePostCommand &
:' (
IRequest) 1
<1 2)
CreateBasePostCommandResponse2 O
>O P
{ 
public 
string 
	TitlePost 
{  !
get" %
;% &
set' *
;* +
}, -
=. /
default0 7
!7 8
;8 9
public 
double 
Price 
{ 
get !
;! "
set# &
;& '
}( )
=* +
default, 3
!3 4
;4 5
public		 
Guid		 
	AddressId		 
{		 
get		  #
;		# $
set		% (
;		( )
}		* +
=		, -
default		. 5
!		5 6
;		6 7
public

 
bool

 
	OfferType

 
{

 
get

  #
;

# $
set

% (
;

( )
}

* +
=

, -
default

. 5
!

5 6
;

6 7
public 
string 
UserId 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
default- 4
!4 5
;5 6
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
default2 9
!9 :
;: ;
} 
} ¬(
pD:\Real-Estate\RealEstate.Application\Features\BasePosts\Commands\CreateBasePost\CreateBasePostCommandHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

Categories* 4
.4 5
Commands5 =
.= >
CreateBasePost> L
{ 
public 

class (
CreateBasePostCommandHandler -
:. /
IRequestHandler0 ?
<? @!
CreateBasePostCommand@ U
,U V)
CreateBasePostCommandResponseW t
>t u
{ 
private		 
readonly		 
IBasePostRepository		 ,

repository		- 7
;		7 8
public (
CreateBasePostCommandHandler +
(+ ,
IBasePostRepository, ?

repository@ J
)J K
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< )
CreateBasePostCommandResponse 7
>7 8
Handle9 ?
(? @!
CreateBasePostCommand@ U
requestV ]
,] ^
CancellationToken_ p
cancellationToken	q Ç
)
Ç É
{ 	
var 
	validator 
= 
new *
CreateBasePostCommandValidator  >
(> ?
)? @
;@ A
var 
validatorResult 
=  !
await" '
	validator( 1
.1 2
ValidateAsync2 ?
(? @
request@ G
,G H
cancellationTokenI Z
)Z [
;[ \
if 
( 
! 
validatorResult 
.  
IsValid  '
)' (
{ 
return 
new )
CreateBasePostCommandResponse 8
{ 
Success 
= 
false #
,# $
ValidationErrors $
=% &
validatorResult' 6
.6 7
Errors7 =
.= >
Select> D
(D E
eE F
=>G I
eJ K
.K L
ErrorMessageL X
)X Y
.Y Z
ToListZ `
(` a
)a b
} 
; 
} 
var 
basePost 
= 
BasePost #
.# $
Create$ *
(* +
request+ 2
.2 3
UserId3 9
,9 :
request; B
.B C
	TitlePostC L
,L M
requestN U
.U V
PriceV [
,[ \
request] d
.d e
	AddressIde n
,n o
requestp w
.w x
	OfferType	x Å
,
Å Ç
request
É ä
.
ä ã
Description
ã ñ
)
ñ ó
;
ó ò
if   
(   
!   
basePost   
.   
	IsSuccess   "
)  " #
{!! 
return"" 
new"" )
CreateBasePostCommandResponse"" 8
{## 
Success$$ 
=$$ 
false$$ #
,$$# $
ValidationErrors%% $
=%%% &
new%%' *
List%%+ /
<%%/ 0
string%%0 6
>%%6 7
(%%7 8
)%%8 9
{%%: ;
basePost%%< D
.%%D E
Error%%E J
}%%K L
}&& 
;&& 
}'' 
await)) 

repository)) 
.)) 
AddAsync)) %
())% &
basePost))& .
.)). /
Value))/ 4
)))4 5
;))5 6
return++ 
new++ )
CreateBasePostCommandResponse++ 4
{,, 
Success-- 
=-- 
true-- 
,-- 
BasePost.. 
=.. 
new.. 
CreateBasePostDto.. 0
{// 

BasePostId00 
=00  
basePost00! )
.00) *
Value00* /
.00/ 0

BasePostId000 :
,00: ;
	TitlePost11 
=11 
basePost11  (
.11( )
Value11) .
.11. /
	TitlePost11/ 8
,118 9
Price22 
=22 
basePost22 $
.22$ %
Value22% *
.22* +
Price22+ 0
,220 1
	AddressId33 
=33 
basePost33  (
.33( )
Value33) .
.33. /
	AddressId33/ 8
,338 9
	OfferType44 
=44 
basePost44  (
.44( )
Value44) .
.44. /
	OfferType44/ 8
,448 9
UserId55 
=55 
basePost55 %
.55% &
Value55& +
.55+ ,
UserId55, 2
,552 3
Description66 
=66  !
basePost66" *
.66* +
Value66+ 0
.660 1
Description661 <
}77 
}88 
;88 
}99 	
}:: 
};; ¯
qD:\Real-Estate\RealEstate.Application\Features\BasePosts\Commands\CreateBasePost\CreateBasePostCommandResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

Categories* 4
.4 5
Commands5 =
.= >
CreateBasePost> L
{ 
public 

class )
CreateBasePostCommandResponse .
:/ 0
BaseResponse1 =
{ 
public )
CreateBasePostCommandResponse ,
(, -
)- .
:/ 0
base1 5
(5 6
)6 7
{ 	
}		 	
public 
CreateBasePostDto  
BasePost! )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
} 
} Ï
rD:\Real-Estate\RealEstate.Application\Features\BasePosts\Commands\CreateBasePost\CreateBasePostCommandValidator.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

Categories* 4
.4 5
Commands5 =
.= >
CreateBasePost> L
{ 
public 

class *
CreateBasePostCommandValidator /
:0 1
AbstractValidator2 C
<C D!
CreateBasePostCommandD Y
>Y Z
{ 
public *
CreateBasePostCommandValidator -
(- .
). /
{ 	
RuleFor		 
(		 
p		 
=>		 
p		 
.		 
	TitlePost		 $
)		$ %
.

 
NotEmpty

 
(

 
)

 
.

 
WithMessage

 '
(

' (
$str

( E
)

E F
. 
NotNull 
( 
) 
. 
MaximumLength 
( 
$num "
)" #
.# $
WithMessage$ /
(/ 0
$str0 `
)` a
;a b
RuleFor 
( 
p 
=> 
p 
. 
Price  
)  !
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
	AddressId $
)$ %
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
	OfferType $
)$ %
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
UserId !
)! "
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
Description &
)& '
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
.   
NotNull   
(   
)   
.!! 
MaximumLength!! 
(!! 
$num!! #
)!!# $
.!!$ %
WithMessage!!% 0
(!!0 1
$str!!1 b
)!!b c
;!!c d
}"" 	
}## 
}$$ ‚
eD:\Real-Estate\RealEstate.Application\Features\BasePosts\Commands\CreateBasePost\CreateBasePostDto.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

Categories* 4
.4 5
Commands5 =
.= >
CreateBasePost> L
{ 
public 

class 
CreateBasePostDto "
{ 
public 
Guid 

BasePostId 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
? 
	TitlePost  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
double 
? 
Price 
{ 
get "
;" #
set$ '
;' (
}) *
public 
Guid 
	AddressId 
{ 
get  #
;# $
set% (
;( )
}* +
public		 
bool		 
?		 
	OfferType		 
{		  
get		! $
;		$ %
set		& )
;		) *
}		+ ,
public

 
string

 
?

 
UserId

 
{

 
get

  #
;

# $
set

% (
;

( )
}

* +
public 
string 
? 
Description "
{# $
get% (
;( )
set* -
;- .
}/ 0
} 
} “
bD:\Real-Estate\RealEstate.Application\Features\BasePosts\Commands\DeleteBasePost\DeleteBasePost.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
	BasePosts* 3
.3 4
Commands4 <
.< =
DeleteBasePost= K
{ 
public 

class 
DeleteBasePost 
:  !
IRequest" *
<* +"
DeleteBasePostResponse+ A
>A B
{ 
public 
Guid 

BasePostId 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
}		 ê
iD:\Real-Estate\RealEstate.Application\Features\BasePosts\Commands\DeleteBasePost\DeleteBasePostHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
	BasePosts* 3
.3 4
Commands4 <
.< =
DeleteBasePost= K
{ 
public 

class !
DeleteBasePostHandler &
:' (
IRequestHandler) 8
<8 9
DeleteBasePost9 G
,G H"
DeleteBasePostResponseI _
>_ `
{ 
private 
readonly 
IBasePostRepository ,

repository- 7
;7 8
public

 !
DeleteBasePostHandler

 $
(

$ %
IBasePostRepository

% 8

repository

9 C
)

C D
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< "
DeleteBasePostResponse 0
>0 1
Handle2 8
(8 9
DeleteBasePost9 G
requestH O
,O P
CancellationTokenQ b
cancellationTokenc t
)t u
{ 	
var 
result 
= 
await 

repository )
.) *
DeleteAsync* 5
(5 6
request6 =
.= >

BasePostId> H
)H I
;I J
if 
( 
! 
result 
. 
	IsSuccess  
)  !
{ 
return 
new "
DeleteBasePostResponse 1
{ 
Success 
= 
false #
,# $
ValidationErrors $
=% &
new' *
List+ /
</ 0
string0 6
>6 7
{8 9
result: @
.@ A
ErrorA F
}G H
} 
; 
} 
return 
new "
DeleteBasePostResponse -
{ 
Success 
= 
true 
} 
; 
} 	
}   
}!! à
jD:\Real-Estate\RealEstate.Application\Features\BasePosts\Commands\DeleteBasePost\DeleteBasePostResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
	BasePosts* 3
.3 4
Commands4 <
.< =
DeleteBasePost= K
{ 
public 

class "
DeleteBasePostResponse '
:( )
BaseResponse* 6
{ 
} 
} ¶
iD:\Real-Estate\RealEstate.Application\Features\BasePosts\Commands\UpdateBasePost\UpdateBasePostCommand.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
	BasePosts* 3
.3 4
Commands4 <
.< =
UpdateBasePost= K
{ 
public 
class !
UpdateBasePostCommand #
:# $
IRequest% -
<- .)
UpdateBasePostCommandResponse. K
>K L
{ 
public 
Guid	 
Id 
{ 
get 
; 
set 
; 
} 
public		 
string			 
?		 
UserId		 
{		 
get		 
;		 
set		 "
;		" #
}		$ %
public

 
string

	 
	TitlePost

 
{

 
get

 
;

  
set

! $
;

$ %
}

& '
=

( )
default

* 1
!

1 2
;

2 3
public 
List	 
< 
string 
> 
Images 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
default- 4
!4 5
;5 6
public 
bool	 
	OfferType 
{ 
get 
; 
set "
;" #
}$ %
=& '
default( /
!/ 0
;0 1
public 
double	 
Price 
{ 
get 
; 
set  
;  !
}" #
=$ %
default& -
!- .
;. /
public 
Guid	 
	AddressId 
{ 
get 
; 
set "
;" #
}$ %
public 
string	 

Descripion 
{ 
get  
;  !
set" %
;% &
}' (
=) *
default+ 2
!2 3
;3 4
} 
} ‹4
pD:\Real-Estate\RealEstate.Application\Features\BasePosts\Commands\UpdateBasePost\UpdateBasePostCommandHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
	BasePosts* 3
.3 4
Commands4 <
.< =
UpdateBasePost= K
{ 
public 
class (
UpdateBasePostCommandHandler *
:* +
IRequestHandler, ;
<; <!
UpdateBasePostCommand< Q
,Q R)
UpdateBasePostCommandResponseS p
>p q
{ 
private 	
readonly
 
IBasePostRepository &

repository' 1
;1 2
public		 (
UpdateBasePostCommandHandler			 %
(		% &
IBasePostRepository		& 9

repository		: D
)		D E
{

 
this 
. 

repository 
= 

repository 
;  
} 
public 
async	 
Task 
< )
UpdateBasePostCommandResponse 1
>1 2
Handle3 9
(9 :!
UpdateBasePostCommand: O
requestP W
,W X
CancellationTokenY j
cancellationTokenk |
)| }
{ 
var 
basePost 
= 
await 

repository "
." #
FindByIdAsync# 0
(0 1
request1 8
.8 9
Id9 ;
); <
;< =
var 
	validator 
= 
new *
UpdateBasePostCommandValidator 5
(5 6
)6 7
;7 8
var 
validatorResult 
= 
await 
	validator (
.( )
ValidateAsync) 6
(6 7
request7 >
,> ?
cancellationToken@ Q
)Q R
;R S
if 
( 
! 
validatorResult 
. 
IsValid 
)  
{ 
return 

new )
UpdateBasePostCommandResponse ,
{ 
Success 
= 
false 
, 
ValidationErrors 
= 
validatorResult '
.' (
Errors( .
.. /
Select/ 5
(5 6
e6 7
=>8 :
e; <
.< =
ErrorMessage= I
)I J
.J K
ToListK Q
(Q R
)R S
} 
; 
} 
if 
( 
! 
basePost 
. 
	IsSuccess 
) 
{ 
return 

new )
UpdateBasePostCommandResponse ,
{ 
Success   
=   
false   
,   
ValidationErrors!! 
=!! 
new!! 
List!!  
<!!  !
string!!! '
>!!' (
(!!( )
)!!) *
{!!+ ,
basePost!!- 5
.!!5 6
Error!!6 ;
}!!< =
}"" 
;"" 
}## 
basePost%% 
.%% 
Value%% 
.%% 
AttachTitlePost%% !
(%%! "
request%%" )
.%%) *
	TitlePost%%* 3
)%%3 4
;%%4 5
basePost&& 
.&& 
Value&& 
.&& 
AttachImages&& 
(&& 
request&& &
.&&& '
Images&&' -
)&&- .
;&&. /
basePost'' 
.'' 
Value'' 
.'' 
AttachOfferType'' !
(''! "
request''" )
.'') *
	OfferType''* 3
)''3 4
;''4 5
basePost(( 
.(( 
Value(( 
.(( 
AttachPrice(( 
((( 
request(( %
.((% &
Price((& +
)((+ ,
;((, -
basePost)) 
.)) 
Value)) 
.)) 
AttachAddressId)) !
())! "
request))" )
.))) *
	AddressId))* 3
)))3 4
;))4 5
basePost** 
.** 
Value** 
.** 
AttachDescription** #
(**# $
request**$ +
.**+ ,

Descripion**, 6
)**6 7
;**7 8
var++ 
updatedBasePost++ 
=++ 
await++ 

repository++ )
.++) *
UpdateAsync++* 5
(++5 6
basePost++6 >
.++> ?
Value++? D
)++D E
;++E F
if-- 
(-- 
!-- 
updatedBasePost-- 
.-- 
	IsSuccess-- !
)--! "
{.. 
return// 

new// )
UpdateBasePostCommandResponse// ,
{00 
Success11 
=11 
false11 
,11 
ValidationErrors22 
=22 
new22 
List22  
<22  !
string22! '
>22' (
(22( )
)22) *
{22+ ,
updatedBasePost22- <
.22< =
Error22= B
}22C D
}33 
;33 
}44 
return66 	
new66
 )
UpdateBasePostCommandResponse66 +
{77 
Success88 
=88 
true88 
,88 
BasePost99 
=99 
new99 
UpdateBasePostDto99 $
{:: 
UserId;; 
=;; 
updatedBasePost;; 
.;; 
Value;; #
.;;# $
UserId;;$ *
,;;* +
	TitlePost<< 
=<< 
updatedBasePost<<  
.<<  !
Value<<! &
.<<& '
	TitlePost<<' 0
,<<0 1
Images== 
=== 
updatedBasePost== 
.== 
Value== #
.==# $
Images==$ *
,==* +
	OfferType>> 
=>> 
updatedBasePost>>  
.>>  !
Value>>! &
.>>& '
	OfferType>>' 0
,>>0 1
Price?? 

=?? 
updatedBasePost?? 
.?? 
Value?? "
.??" #
Price??# (
,??( )
	AddressId@@ 
=@@ 
updatedBasePost@@  
.@@  !
Value@@! &
.@@& '
	AddressId@@' 0
,@@0 1

DescripionAA 
=AA 
updatedBasePostAA !
.AA! "
ValueAA" '
.AA' (
DescriptionAA( 3
}BB 
}CC 
;CC 
}DD 
}EE 
}FF ˜
qD:\Real-Estate\RealEstate.Application\Features\BasePosts\Commands\UpdateBasePost\UpdateBasePostCommandResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
	BasePosts* 3
.3 4
Commands4 <
.< =
UpdateBasePost= K
{ 
public 
class )
UpdateBasePostCommandResponse +
:+ ,
BaseResponse- 9
{ 
public )
UpdateBasePostCommandResponse	 &
(& '
)' (
:( )
base* .
(. /
)/ 0
{ 
}		 
public

 
UpdateBasePostDto

	 
BasePost

 #
{

$ %
get

& )
;

) *
set

+ .
;

. /
}

0 1
} 
} ¥!
rD:\Real-Estate\RealEstate.Application\Features\BasePosts\Commands\UpdateBasePost\UpdateBasePostCommandValidator.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
	BasePosts* 3
.3 4
Commands4 <
.< =
UpdateBasePost= K
{ 
public 
class *
UpdateBasePostCommandValidator ,
:, -
AbstractValidator. ?
<? @!
UpdateBasePostCommand@ U
>U V
{ 
public *
UpdateBasePostCommandValidator	 '
(' (
)( )
{ 
RuleFor		 

(		
 
p		 
=>		 
p		 
.		 
Id		 
)		 
.

 
NotEmpty

 
(

 
)

 
.

 
WithMessage

 
(

 
$str

 9
)

9 :
. 
NotNull 
( 
) 
. 
NotEqual 
( 
Guid 
. 
Empty 
) 
; 
RuleFor 

(
 
p 
=> 
p 
. 
	TitlePost 
) 
. 
NotEmpty 
( 
) 
. 
WithMessage 
( 
$str 9
)9 :
. 
NotNull 
( 
) 
. 
MaximumLength 
( 
$num 
) 
. 
WithMessage 
( 
$str A
)A B
;B C
RuleFor 

(
 
p 
=> 
p 
. 
Images 
) 
. 
NotEmpty 
( 
) 
. 
WithMessage 
( 
$str 9
)9 :
. 
NotNull 
( 
) 
; 
RuleFor 

(
 
p 
=> 
p 
. 
	OfferType 
) 
. 
NotEmpty 
( 
) 
. 
WithMessage 
( 
$str 9
)9 :
. 
NotNull 
( 
) 
; 
RuleFor 

(
 
p 
=> 
p 
. 
Price 
) 
. 
NotEmpty 
( 
) 
. 
WithMessage 
( 
$str 9
)9 :
. 
NotNull 
( 
) 
; 
RuleFor   

(  
 
p   
=>   
p   
.   
	AddressId   
)   
.!! 
NotEmpty!! 
(!! 
)!! 
.!! 
WithMessage!! 
(!! 
$str!! 9
)!!9 :
."" 
NotNull"" 
("" 
)"" 
.## 
NotEqual## 
(## 
Guid## 
.## 
Empty## 
)## 
;## 
RuleFor%% 

(%%
 
p%% 
=>%% 
p%% 
.%% 

Descripion%% 
)%% 
.&& 
NotEmpty&& 
(&& 
)&& 
.&& 
WithMessage&& 
(&& 
$str&& 9
)&&9 :
.'' 
NotNull'' 
('' 
)'' 
.(( 
MaximumLength(( 
((( 
$num(( 
)(( 
.)) 
WithMessage)) 
()) 
$str)) A
)))A B
;))B C
RuleFor++ 

(++
 
p++ 
=>++ 
p++ 
.++ 
UserId++ 
)++ 
.,, 
NotEmpty,, 
(,, 
),, 
.,, 
WithMessage,, 
(,, 
$str,, 9
),,9 :
.-- 
NotNull-- 
(-- 
)-- 
;-- 
}// 
}00 
}11 ù
eD:\Real-Estate\RealEstate.Application\Features\BasePosts\Commands\UpdateBasePost\UpdateBasePostDto.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
	BasePosts* 3
.3 4
Commands4 <
.< =
UpdateBasePost= K
{ 
public 
class 
UpdateBasePostDto 
{ 
public 
string	 
? 
UserId 
{ 
get 
; 
set "
;" #
}$ %
public 
string	 
? 
	TitlePost 
{ 
get  
;  !
set" %
;% &
}' (
public		 
List			 
<		 
string		 
>		 
?		 
Images		 
{		 
get		  #
;		# $
set		% (
;		( )
}		* +
public

 
bool

	 
?

 
	OfferType

 
{

 
get

 
;

 
set

  #
;

# $
}

% &
public 
double	 
? 
Price 
{ 
get 
; 
set !
;! "
}# $
public 
Guid	 
	AddressId 
{ 
get 
; 
set "
;" #
}$ %
public 
string	 
? 

Descripion 
{ 
get !
;! "
set# &
;& '
}( )
} 
} ò
OD:\Real-Estate\RealEstate.Application\Features\BasePosts\Queries\BasePostDto.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
	BasePosts* 3
.3 4
Queries4 ;
{ 
public 

class 
BasePostDto 
{ 
public 
Guid 

BasePostId 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
	TitlePost 
{  !
get" %
;% &
set' *
;* +
}, -
=. /
default0 7
!7 8
;8 9
public 
double 
Price 
{ 
get !
;! "
set# &
;& '
}( )
=* +
default, 3
!3 4
;4 5
public 
Guid 
	AddressId 
{ 
get  #
;# $
set% (
;( )
}* +
public		 
bool		 
	OfferType		 
{		 
get		  #
;		# $
set		% (
;		( )
}		* +
=		, -
default		. 5
!		5 6
;		6 7
public

 
string

 
UserId

 
{

 
get

 "
;

" #
set

$ '
;

' (
}

) *
=

+ ,
default

- 4
!

4 5
;

5 6
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
default2 9
!9 :
;: ;
} 
} ±
_D:\Real-Estate\RealEstate.Application\Features\BasePosts\Queries\GetAll\GetAllBasePostsQuery.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
	BasePosts* 3
.3 4
Queries4 ;
.; <
GetAll< B
{ 
public 

class  
GetAllBasePostsQuery %
:& '
IRequest( 0
<0 1#
GetAllBasePostsResponse1 H
>H I
{ 
} 
} ÷
fD:\Real-Estate\RealEstate.Application\Features\BasePosts\Queries\GetAll\GetAllBasePostsQueryHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
	BasePosts* 3
.3 4
Queries4 ;
.; <
GetAll< B
{ 
public 

class '
GetAllBasePostsQueryHandler ,
:- .
IRequestHandler/ >
<> ? 
GetAllBasePostsQuery? S
,S T#
GetAllBasePostsResponseU l
>l m
{ 
private 
readonly 
IBasePostRepository ,

repository- 7
;7 8
public

 '
GetAllBasePostsQueryHandler

 *
(

* +
IBasePostRepository

+ >

repository

? I
)

I J
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< #
GetAllBasePostsResponse 1
>1 2
Handle3 9
(9 : 
GetAllBasePostsQuery: N
requestO V
,V W
CancellationTokenX i
cancellationTokenj {
){ |
{ 	#
GetAllBasePostsResponse #
response$ ,
=- .
new/ 2
(2 3
)3 4
;4 5
var 
result 
= 
await 

repository )
.) *
GetAllAsync* 5
(5 6
)6 7
;7 8
if 
( 
result 
. 
	IsSuccess 
)  
{ 
response 
. 
	BasePosts "
=# $
result% +
.+ ,
Value, 1
.1 2
Select2 8
(8 9
basePost9 A
=>B D
newE H
BasePostDtoI T
{ 

BasePostId 
=  
basePost! )
.) *

BasePostId* 4
,4 5
	TitlePost 
= 
basePost  (
.( )
	TitlePost) 2
,2 3
Price 
= 
basePost $
.$ %
Price% *
,* +
	AddressId 
= 
basePost  (
.( )
	AddressId) 2
,2 3
	OfferType 
= 
basePost  (
.( )
	OfferType) 2
,2 3
UserId 
= 
basePost %
.% &
UserId& ,
,, -
Description 
=  !
basePost" *
.* +
Description+ 6
} 
) 
. 
ToList 
( 
) 
; 
}   
return!! 
response!! 
;!! 
}"" 	
}## 
}$$ °
bD:\Real-Estate\RealEstate.Application\Features\BasePosts\Queries\GetAll\GetAllBasePostsResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
	BasePosts* 3
.3 4
Queries4 ;
.; <
GetAll< B
{ 
public 

class #
GetAllBasePostsResponse (
{ 
public 
List 
< 
BasePostDto 
>  
	BasePosts! *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
} 
} ·
`D:\Real-Estate\RealEstate.Application\Features\BasePosts\Queries\GetById\GetByIdBasePostQuery.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
	BasePosts* 3
.3 4
Queries4 ;
.; <
GetById< C
{ 
public 

record  
GetByIdBasePostQuery &
(& '
Guid' +

BasePostId, 6
)6 7
:8 9
IRequest: B
<B C
BasePostDtoC N
>N O
;O P
} Ö
gD:\Real-Estate\RealEstate.Application\Features\BasePosts\Queries\GetById\GetByIdBasePostQueryHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
	BasePosts* 3
.3 4
Queries4 ;
.; <
GetById< C
{ 
public 

class '
GetByIdBasePostQueryHandler ,
:- .
IRequestHandler/ >
<> ? 
GetByIdBasePostQuery? S
,S T
BasePostDtoU `
>` a
{ 
private 
readonly 
IBasePostRepository ,

repository- 7
;7 8
public

 '
GetByIdBasePostQueryHandler

 *
(

* +
IBasePostRepository

+ >

repository

? I
)

I J
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< 
BasePostDto %
>% &
Handle' -
(- . 
GetByIdBasePostQuery. B
requestC J
,J K
CancellationTokenL ]
cancellationToken^ o
)o p
{ 	
var 
basePost 
= 
await  

repository! +
.+ ,
FindByIdAsync, 9
(9 :
request: A
.A B

BasePostIdB L
)L M
;M N
if 
( 
basePost 
. 
	IsSuccess !
)! "
{ 
return 
new 
BasePostDto &
{ 

BasePostId 
=  
basePost! )
.) *
Value* /
./ 0

BasePostId0 :
,: ;
	TitlePost 
= 
basePost  (
.( )
Value) .
.. /
	TitlePost/ 8
,8 9
Price 
= 
basePost $
.$ %
Value% *
.* +
Price+ 0
,0 1
	AddressId 
= 
basePost  (
.( )
Value) .
.. /
	AddressId/ 8
,8 9
	OfferType 
= 
basePost  (
.( )
Value) .
.. /
	OfferType/ 8
,8 9
UserId 
= 
basePost %
.% &
Value& +
.+ ,
UserId, 2
,2 3
Description 
=  !
basePost" *
.* +
Value+ 0
.0 1
Description1 <
} 
; 
} 
return   
new   
BasePostDto   "
(  " #
)  # $
;  $ %
}!! 	
}"" 
}## Ã
cD:\Real-Estate\RealEstate.Application\Features\Clients\Commands\CreateClient\CreateClientCommand.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

Categories* 4
.4 5
Commands5 =
.= >
CreateClient> J
{ 
public 

class 
CreateClientCommand $
:% &
IRequest' /
</ 0'
CreateClientCommandResponse0 K
>K L
{ 
public 
Guid 
UserId 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
Username 
{  
get! $
;$ %
set& )
;) *
}+ ,
=- .
default/ 6
!6 7
;7 8
public		 
string		 
Email		 
{		 
get		 !
;		! "
set		# &
;		& '
}		( )
=		* +
default		, 3
!		3 4
;		4 5
public

 
string

 
Name

 
{

 
get

  
;

  !
set

" %
;

% &
}

' (
=

) *
default

+ 2
!

2 3
;

3 4
public 
string 
PhoneNumber !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
default2 9
!9 :
;: ;
} 
} ˆ$
jD:\Real-Estate\RealEstate.Application\Features\Clients\Commands\CreateClient\CreateClientCommandHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

Categories* 4
.4 5
Commands5 =
.= >
CreateClient> J
{ 
public 

class &
CreateClientCommandHandler +
:, -
IRequestHandler. =
<= >
CreateClientCommand> Q
,Q R'
CreateClientCommandResponseS n
>n o
{ 
private		 
readonly		 
IClientRepository		 *

repository		+ 5
;		5 6
public &
CreateClientCommandHandler )
() *
IClientRepository* ;

repository< F
)F G
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< '
CreateClientCommandResponse 5
>5 6
Handle7 =
(= >
CreateClientCommand> Q
requestR Y
,Y Z
CancellationToken[ l
cancellationTokenm ~
)~ 
{ 	
var 
	validator 
= 
new (
CreateClientCommandValidator  <
(< =
)= >
;> ?
var 
validatorResult 
=  !
await" '
	validator( 1
.1 2
ValidateAsync2 ?
(? @
request@ G
,G H
cancellationTokenI Z
)Z [
;[ \
if 
( 
! 
validatorResult 
.  
IsValid  '
)' (
{ 
return 
new '
CreateClientCommandResponse 6
{ 
Success 
= 
false #
,# $
ValidationErrors $
=% &
validatorResult' 6
.6 7
Errors7 =
.= >
Select> D
(D E
eE F
=>G I
eJ K
.K L
ErrorMessageL X
)X Y
.Y Z
ToListZ `
(` a
)a b
} 
; 
} 
var 
client 
= 
Client 
.  
Create  &
(& '
request' .
.. /
UserId/ 5
,5 6
request7 >
.> ?
Username? G
,G H
requestI P
.P Q
EmailQ V
,V W
requestX _
._ `
Name` d
,d e
requeste l
.l m
PhoneNumberm x
)x y
;y z
if 
( 
! 
client 
. 
	IsSuccess  
)  !
{   
return!! 
new!! '
CreateClientCommandResponse!! 6
{"" 
Success## 
=## 
false## #
,### $
ValidationErrors$$ $
=$$% &
new$$' *
List$$+ /
<$$/ 0
string$$0 6
>$$6 7
($$7 8
)$$8 9
{$$: ;
client$$< B
.$$B C
Error$$C H
}$$I J
}%% 
;%% 
}&& 
await(( 

repository(( 
.(( 
AddAsync(( %
(((% &
client((& ,
.((, -
Value((- 2
)((2 3
;((3 4
return** 
new** '
CreateClientCommandResponse** 2
{++ 
Success,, 
=,, 
true,, 
,,, 
Client-- 
=-- 
new-- 
CreateClientDto-- ,
{.. 
UserId// 
=// 
client// #
.//# $
Value//$ )
.//) *
UserId//* 0
,//0 1
Username00 
=00 
client00 %
.00% &
Value00& +
.00+ ,
Username00, 4
,004 5
Email11 
=11 
client11 "
.11" #
Value11# (
.11( )
Email11) .
,11. /
Name22 
=22 
client22 !
.22! "
Value22" '
.22' (
Name22( ,
,22, -
PhoneNumber33 
=33  !
client33" (
.33( )
Value33) .
.33. /
PhoneNumber33/ :
}44 
}55 
;55 
}77 	
}88 
}99 Ë
kD:\Real-Estate\RealEstate.Application\Features\Clients\Commands\CreateClient\CreateClientCommandResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

Categories* 4
.4 5
Commands5 =
.= >
CreateClient> J
{ 
public 

class '
CreateClientCommandResponse ,
:- .
BaseResponse/ ;
{ 
public '
CreateClientCommandResponse *
(* +
)+ ,
: 
base 
( 
) 
{		 	
}

 	
public 
CreateClientDto 
Client %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
} 
} Å
lD:\Real-Estate\RealEstate.Application\Features\Clients\Commands\CreateClient\CreateClientCommandValidator.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

Categories* 4
.4 5
Commands5 =
.= >
CreateClient> J
{ 
public 

class (
CreateClientCommandValidator -
:. /
AbstractValidator0 A
<A B
CreateClientCommandB U
>U V
{ 
public (
CreateClientCommandValidator +
(+ ,
), -
{ 	
RuleFor		 
(		 
p		 
=>		 
p		 
.		 
UserId		 !
)		! "
.

 
NotEmpty

 
(

 
)

 
.

 
WithMessage

 (
(

( )
$str

) F
)

F G
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
Username #
)# $
. 
NotEmpty 
( 
) 
. 
WithMessage (
(( )
$str) F
)F G
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
Email  
)  !
. 
NotEmpty 
( 
) 
. 
WithMessage (
(( )
$str) F
)F G
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
Name 
)  
. 
NotEmpty 
( 
) 
. 
WithMessage (
(( )
$str) F
)F G
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
PhoneNumber &
)& '
. 
NotEmpty 
( 
) 
. 
WithMessage (
(( )
$str) F
)F G
. 
NotNull 
( 
) 
; 
} 	
} 
} ÿ
_D:\Real-Estate\RealEstate.Application\Features\Clients\Commands\CreateClient\CreateClientDto.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

Categories* 4
.4 5
Commands5 =
.= >
CreateClient> J
{ 
public 

class 
CreateClientDto  
{ 
public 
Guid 
UserId 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
Username 
{  
get! $
;$ %
set& )
;) *
}+ ,
=- .
default/ 6
!6 7
;7 8
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
=* +
default, 3
!3 4
;4 5
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
=) *
default+ 2
!2 3
;3 4
public		 
string		 
PhoneNumber		 !
{		" #
get		$ '
;		' (
set		) ,
;		, -
}		. /
=		0 1
default		2 9
!		9 :
;		: ;
} 
} ¿
\D:\Real-Estate\RealEstate.Application\Features\Clients\Commands\DeleteClient\DeleteClient.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Clients* 1
.1 2
Commands2 :
.: ;
DeleteClient; G
{ 
public 

class 
DeleteClient 
: 
IRequest  (
<( ) 
DeleteClientResponse) =
>= >
{ 
public 
Guid 
UserId 
{ 
get  
;  !
set" %
;% &
}' (
} 
}		 Ó
cD:\Real-Estate\RealEstate.Application\Features\Clients\Commands\DeleteClient\DeleteClientHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Clients* 1
.1 2
Commands2 :
.: ;
DeleteClient; G
{ 
public 

class 
DeleteClientHandler $
:% &
IRequestHandler' 6
<6 7
DeleteClient7 C
,C D 
DeleteClientResponseE Y
>Y Z
{ 
private 
readonly 
IClientRepository *

repository+ 5
;5 6
public

 
DeleteClientHandler

 "
(

" #
IClientRepository

# 4

repository

5 ?
)

? @
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
<  
DeleteClientResponse .
>. /
Handle0 6
(6 7
DeleteClient7 C
requestD K
,K L
CancellationTokenM ^
cancellationToken_ p
)p q
{ 	
var 
result 
= 
await 

repository )
.) *
DeleteAsync* 5
(5 6
request6 =
.= >
UserId> D
)D E
;E F
if 
( 
! 
result 
. 
	IsSuccess !
)! "
{ 
return 
new  
DeleteClientResponse /
{ 
Success 
= 
false #
,# $
ValidationErrors $
=% &
new' *
List+ /
</ 0
string0 6
>6 7
{8 9
result: @
.@ A
ErrorA F
}G H
} 
; 
} 
return 
new  
DeleteClientResponse +
{ 
Success 
= 
true 
} 
; 
} 	
}   
}!! ¸
dD:\Real-Estate\RealEstate.Application\Features\Clients\Commands\DeleteClient\DeleteClientResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Clients* 1
.1 2
Commands2 :
.: ;
DeleteClient; G
{ 
public 

class  
DeleteClientResponse %
:& '
BaseResponse( 4
{ 
} 
} Ó

cD:\Real-Estate\RealEstate.Application\Features\Clients\Commands\UpdateClient\UpdateClientCommand.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Clients* 1
.1 2
Commands2 :
.: ;
UpdateClient; G
{ 
public 

class 
UpdateClientCommand $
:% &
IRequest' /
</ 0'
UpdateClientCommandResponse0 K
>K L
{ 
public 
Guid 
UserId 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
=) *
default+ 2
!2 3
;3 4
public		 
string		 
PhoneNumber		 !
{		" #
get		$ '
;		' (
set		) ,
;		, -
}		. /
=		0 1
default		2 9
!		9 :
;		: ;
public

 
string

 
ImageUrl

 
{

  
get

! $
;

$ %
set

& )
;

) *
}

+ ,
=

- .
default

/ 6
!

6 7
;

7 8
} 
} ¸*
jD:\Real-Estate\RealEstate.Application\Features\Clients\Commands\UpdateClient\UpdateClientCommandHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Clients* 1
.1 2
Commands2 :
.: ;
UpdateClient; G
{ 
public 

class &
UpdateClientCommandHandler +
:, -
IRequestHandler. =
<= >
UpdateClientCommand> Q
,Q R'
UpdateClientCommandResponseS n
>n o
{ 
private 
readonly 
IClientRepository *

repository+ 5
;5 6
public

 &
UpdateClientCommandHandler

 )
(

) *
IClientRepository

* ;

repository

< F
)

F G
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< '
UpdateClientCommandResponse 5
>5 6
Handle7 =
(= >
UpdateClientCommand> Q
requestR Y
,Y Z
CancellationToken[ l
cancellationTokenm ~
)~ 
{ 	
var 
client 
= 
await 

repository )
.) *
FindByIdAsync* 7
(7 8
request8 ?
.? @
UserId@ F
)F G
;G H
var 
	validator 
= 
new (
UpdateClientCommandValidator  <
(< =
)= >
;> ?
var 
validatorResult 
=  !
await" '
	validator( 1
.1 2
ValidateAsync2 ?
(? @
request@ G
,G H
cancellationTokenI Z
)Z [
;[ \
if 
( 
! 
validatorResult 
.  
IsValid  '
)' (
{ 
return 
new '
UpdateClientCommandResponse 6
(6 7
)7 8
{ 
Success 
= 
false #
,# $
ValidationErrors $
=% &
validatorResult' 6
.6 7
Errors7 =
.= >
Select> D
(D E
eE F
=>G I
eJ K
.K L
ErrorMessageL X
)X Y
.Y Z
ToListZ `
(` a
)a b
} 
; 
} 
if 
( 
! 
client 
. 
	IsSuccess !
)! "
{ 
return   
new   '
UpdateClientCommandResponse   6
{!! 
Success"" 
="" 
false"" #
,""# $
ValidationErrors## $
=##% &
new##' *
List##+ /
<##/ 0
string##0 6
>##6 7
(##7 8
)##8 9
{##: ;
client##< B
.##B C
Error##C H
}##I J
}$$ 
;$$ 
}%% 
client'' 
.'' 
Value'' 
.'' 

AttachName'' #
(''# $
request''$ +
.''+ ,
Name'', 0
)''0 1
;''1 2
client(( 
.(( 
Value(( 
.(( 
AttachPhoneNumber(( *
(((* +
request((+ 2
.((2 3
PhoneNumber((3 >
)((> ?
;((? @
client)) 
.)) 
Value)) 
.)) 
AttachImageUrl)) '
())' (
request))( /
.))/ 0
ImageUrl))0 8
)))8 9
;))9 :
var++ 
updatedClient++ 
=++ 
await++  %

repository++& 0
.++0 1
UpdateAsync++1 <
(++< =
client++= C
.++C D
Value++D I
)++I J
;++J K
if-- 
(-- 
!-- 
updatedClient-- 
.-- 
	IsSuccess-- '
)--' (
{.. 
return// 
new// '
UpdateClientCommandResponse// 6
{00 
Success11 
=11 
false11 #
,11# $
ValidationErrors22 $
=22% &
new22' *
List22+ /
<22/ 0
string220 6
>226 7
(227 8
)228 9
{22: ;
updatedClient22< I
.22I J
Error22J O
}22P Q
}33 
;33 
}44 
return66 
new66 '
UpdateClientCommandResponse66 2
{77 
Success88 
=88 
true88 
,88 
Client99 
=99 
new99 
UpdateClientDto99 ,
{:: 
Name;; 
=;; 
updatedClient;; (
.;;( )
Value;;) .
.;;. /
Name;;/ 3
,;;3 4
PhoneNumber<< 
=<<  !
updatedClient<<" /
.<</ 0
Value<<0 5
.<<5 6
PhoneNumber<<6 A
,<<A B
ImageUrl== 
=== 
updatedClient== ,
.==, -
Value==- 2
.==2 3
ImageUrl==3 ;
}>> 
}?? 
;?? 
}@@ 	
}AA 
}BB Â
kD:\Real-Estate\RealEstate.Application\Features\Clients\Commands\UpdateClient\UpdateClientCommandResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Clients* 1
.1 2
Commands2 :
.: ;
UpdateClient; G
{ 
public 

class '
UpdateClientCommandResponse ,
:- .
BaseResponse/ ;
{ 
public '
UpdateClientCommandResponse *
(* +
)+ ,
:- .
base/ 3
(3 4
)4 5
{ 	
}		 	
public 
UpdateClientDto 
Client %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
} 
} Û
lD:\Real-Estate\RealEstate.Application\Features\Clients\Commands\UpdateClient\UpdateClientCommandValidator.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Clients* 1
.1 2
Commands2 :
.: ;
UpdateClient; G
{ 
public 

class (
UpdateClientCommandValidator -
:. /
AbstractValidator0 A
<A B
UpdateClientCommandB U
>U V
{ 
public (
UpdateClientCommandValidator +
(+ ,
), -
{ 	
RuleFor		 
(		 
p		 
=>		 
p		 
.		 
UserId		 !
)		! "
.

 
NotEmpty

 
(

 
)

 
.

 
WithMessage

 '
(

' (
$str

( E
)

E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
Name 
)  
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
. 
MaximumLength 
( 
$num !
)! "
." #
WithMessage# .
(. /
$str/ ^
)^ _
;_ `
RuleFor 
( 
p 
=> 
p 
. 
PhoneNumber &
)& '
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
. 
MaximumLength 
( 
$num !
)! "
." #
WithMessage# .
(. /
$str/ ^
)^ _
;_ `
RuleFor 
( 
p 
=> 
p 
. 
ImageUrl #
)# $
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
; 
} 	
} 
} …
_D:\Real-Estate\RealEstate.Application\Features\Clients\Commands\UpdateClient\UpdateClientDto.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Clients* 1
.1 2
Commands2 :
.: ;
UpdateClient; G
{ 
public 

class 
UpdateClientDto  
{ 
public 
string 
? 
Name 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
? 
PhoneNumber "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
string 
? 
ImageUrl 
{  !
get" %
;% &
set' *
;* +
}, -
}		 
}

 

KD:\Real-Estate\RealEstate.Application\Features\Clients\Queries\ClientDto.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Clients* 1
.1 2
Queries2 9
{ 
public 

class 
	ClientDto 
{ 
public 
Guid 
UserId 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
? 
Username 
{  !
get" %
;% &
set' *
;* +
}, -
public 
string 
? 
Email 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
? 
Name 
{ 
get !
;! "
set# &
;& '
}( )
public		 
string		 
?		 
PhoneNumber		 "
{		# $
get		% (
;		( )
set		* -
;		- .
}		/ 0
public

 
string

 
?

 
ImageUrl

 
{

  !
get

" %
;

% &
set

' *
;

* +
}

, -
} 
} ß
[D:\Real-Estate\RealEstate.Application\Features\Clients\Queries\GetAll\GetAllClientsQuery.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Clients* 1
.1 2
Queries2 9
.9 :
GetAll: @
{ 
public 

class 
GetAllClientsQuery #
:$ %
IRequest& .
<. /!
GetAllClientsResponse/ D
>D E
{ 
} 
} ´
bD:\Real-Estate\RealEstate.Application\Features\Clients\Queries\GetAll\GetAllClientsQueryHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Clients* 1
.1 2
Queries2 9
.9 :
GetAll: @
{ 
public 

class %
GetAllClientsQueryHandler *
:+ ,
IRequestHandler- <
<< =
GetAllClientsQuery= O
,O P!
GetAllClientsResponseQ f
>f g
{ 
private 
readonly 
IClientRepository *

repository+ 5
;5 6
public

 %
GetAllClientsQueryHandler

 (
(

( )
IClientRepository

) :

repository

; E
)

E F
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< !
GetAllClientsResponse /
>/ 0
Handle1 7
(7 8
GetAllClientsQuery8 J
requestK R
,R S
CancellationTokenT e
cancellationTokenf w
)w x
{ 	!
GetAllClientsResponse !
response" *
=+ ,
new- 0
(0 1
)1 2
;2 3
var 
result 
= 
await 

repository )
.) *
GetAllAsync* 5
(5 6
)6 7
;7 8
if 
( 
result 
. 
	IsSuccess 
)  
{ 
response 
. 
Clients  
=! "
result# )
.) *
Value* /
./ 0
Select0 6
(6 7
client7 =
=>> @
newA D
	ClientDtoE N
{ 
UserId 
= 
client #
.# $
UserId$ *
,* +
Username 
= 
client %
.% &
Username& .
,. /
Email 
= 
client "
." #
Email# (
,( )
Name 
= 
client !
.! "
Name" &
,& '
PhoneNumber 
=  !
client" (
.( )
PhoneNumber) 4
,4 5
ImageUrl 
= 
client %
.% &
ImageUrl& .
} 
) 
. 
ToList 
( 
) 
; 
} 
return   
response   
;   
}!! 	
}"" 
}## ï
^D:\Real-Estate\RealEstate.Application\Features\Clients\Queries\GetAll\GetAllClientsResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Clients* 1
.1 2
Queries2 9
.9 :
GetAll: @
{ 
public 

class !
GetAllClientsResponse &
{ 
public 
List 
< 
	ClientDto 
> 
Clients &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
} 
} ”
\D:\Real-Estate\RealEstate.Application\Features\Clients\Queries\GetById\GetByIdClientQuery.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Clients* 1
.1 2
Queries2 9
.9 :
GetById: A
{ 
public 

record 
GetByIdClientQuery $
($ %
Guid% )
UserId* 0
)0 1
:2 3
IRequest4 <
<< =
	ClientDto= F
>F G
;G H
} ¥
cD:\Real-Estate\RealEstate.Application\Features\Clients\Queries\GetById\GetByIdClientQueryHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Clients* 1
.1 2
Queries2 9
.9 :
GetById: A
{ 
public 

class %
GetByIdClientQueryHandler *
:+ ,
IRequestHandler- <
<< =
GetByIdClientQuery= O
,O P
	ClientDtoQ Z
>Z [
{ 
private 
readonly 
IClientRepository *

repository+ 5
;5 6
public

 %
GetByIdClientQueryHandler

 (
(

( )
IClientRepository

) :

repository

; E
)

E F
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< 
	ClientDto #
># $
Handle% +
(+ ,
GetByIdClientQuery, >
request? F
,F G
CancellationTokenH Y
cancellationTokenZ k
)k l
{ 	
var 
client 
= 
await 

repository )
.) *
FindByIdAsync* 7
(7 8
request8 ?
.? @
UserId@ F
)F G
;G H
if 
( 
client 
. 
	IsSuccess 
)  
{ 
return 
new 
	ClientDto $
{ 
UserId 
= 
client #
.# $
Value$ )
.) *
UserId* 0
,0 1
Username 
= 
client %
.% &
Value& +
.+ ,
Username, 4
,4 5
Email 
= 
client "
." #
Value# (
.( )
Email) .
,. /
Name 
= 
client !
.! "
Value" '
.' (
Name( ,
,, -
PhoneNumber 
=  !
client" (
.( )
Value) .
.. /
PhoneNumber/ :
,: ;
ImageUrl 
= 
client %
.% &
Value& +
.+ ,
ImageUrl, 4
} 
; 
} 
return 
new 
	ClientDto  
(  !
)! "
;" #
}   	
}!! 
}"" ˆ
àD:\Real-Estate\RealEstate.Application\Features\CommercialCategories\Commands\CreateCommercialCategory\CreateCommercialCategoryCommand.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) * 
CommercialCategories* >
.> ?
Commands? G
.G H$
CreateCommercialCategoryH `
{ 
public 

class +
CreateCommercialCategoryCommand 0
:1 2
IRequest3 ;
<; <3
'CreateCommercialCategoryCommandResponse< c
>c d
{ 
public 
string 
CategoryName "
{# $
get% (
;( )
set* -
;- .
}/ 0
=1 2
default3 :
!: ;
;; <
} 
}		 ˜!
èD:\Real-Estate\RealEstate.Application\Features\CommercialCategories\Commands\CreateCommercialCategory\CreateCommercialCategoryCommandHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) * 
CommercialCategories* >
.> ?
Commands? G
.G H$
CreateCommercialCategoryH `
{ 
public 
class 2
&CreateCommercialCategoryCommandHandler 4
:5 6
IRequestHandler7 F
<F G+
CreateCommercialCategoryCommandG f
,f g4
'CreateCommercialCategoryCommandResponse	h è
>
è ê
{ 
private		 
readonly		 )
ICommercialCategoryRepository		 6

repository		7 A
;		A B
public 2
&CreateCommercialCategoryCommandHandler 5
(5 6)
ICommercialCategoryRepository6 S

repositoryT ^
)^ _
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< 3
'CreateCommercialCategoryCommandResponse A
>A B
HandleC I
(I J+
CreateCommercialCategoryCommandJ i
requestj q
,q r
CancellationToken	s Ñ
cancellationToken
Ö ñ
)
ñ ó
{ 	
var 
	validator 
= 
new 4
(CreateCommercialCategoryCommandValidator  H
(H I
)I J
;J K
var 
validatorResult 
=  !
await" '
	validator( 1
.1 2
ValidateAsync2 ?
(? @
request@ G
,G H
cancellationTokenI Z
)Z [
;[ \
if 
( 
! 
validatorResult  
.  !
IsValid! (
)( )
{ 
return 
new 3
'CreateCommercialCategoryCommandResponse B
{ 
Success 
= 
false #
,# $
ValidationErrors $
=% &
validatorResult' 6
.6 7
Errors7 =
.= >
Select> D
(D E
eE F
=>G I
eJ K
.K L
ErrorMessageL X
)X Y
.Y Z
ToListZ `
(` a
)a b
} 
; 
} 
var 
commercialCategory "
=# $
CommercialCategory% 7
.7 8
Create8 >
(> ?
request? F
.F G
CategoryNameG S
)S T
;T U
if   
(   
!   
commercialCategory   #
.  # $
	IsSuccess  $ -
)  - .
{!! 
return"" 
new"" 3
'CreateCommercialCategoryCommandResponse"" B
{## 
Success$$ 
=$$ 
false$$ #
,$$# $
ValidationErrors%% $
=%%% &
new%%' *
List%%+ /
<%%/ 0
string%%0 6
>%%6 7
(%%7 8
)%%8 9
{%%: ;
commercialCategory%%< N
.%%N O
Error%%O T
}%%U V
}&& 
;&& 
}'' 
await)) 

repository)) 
.)) 
AddAsync)) %
())% &
commercialCategory))& 8
.))8 9
Value))9 >
)))> ?
;))? @
return++ 
new++ 3
'CreateCommercialCategoryCommandResponse++ >
{,, 
Success-- 
=-- 
true-- 
,-- 
CommercialCategory.. "
=..# $
new..% ('
CreateCommercialCategoryDto..) D
{// 
Id00 
=00 
commercialCategory00 +
.00+ ,
Value00, 1
.001 2
Id002 4
,004 5
CategoryName11  
=11! "
commercialCategory11# 5
.115 6
Value116 ;
.11; <
CategoryName11< H
}22 
}33 
;33 
}44 	
}55 
}66 ‘
êD:\Real-Estate\RealEstate.Application\Features\CommercialCategories\Commands\CreateCommercialCategory\CreateCommercialCategoryCommandResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) * 
CommercialCategories* >
.> ?
Commands? G
.G H$
CreateCommercialCategoryH `
{ 
public 

class 3
'CreateCommercialCategoryCommandResponse 8
:9 :
BaseResponse; G
{ 
public 3
'CreateCommercialCategoryCommandResponse 6
(6 7
)7 8
: 
base 
( 
) 
{		 	
}

 	
public '
CreateCommercialCategoryDto *
CommercialCategory+ =
{> ?
get@ C
;C D
setE H
;H I
}J K
} 
} ’

ëD:\Real-Estate\RealEstate.Application\Features\CommercialCategories\Commands\CreateCommercialCategory\CreateCommercialCategoryCommandValidator.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) * 
CommercialCategories* >
.> ?
Commands? G
.G H$
CreateCommercialCategoryH `
{ 
public 

class 4
(CreateCommercialCategoryCommandValidator 9
:: ;
AbstractValidator< M
<M N+
CreateCommercialCategoryCommandN m
>m n
{ 
public 4
(CreateCommercialCategoryCommandValidator 7
(7 8
)8 9
{ 	
RuleFor		 
(		 
p		 
=>		 
p		 
.		 
CategoryName		 '
)		' (
.

 
NotEmpty

 
(

 
)

 
.

 
WithMessage

 '
(

' (
$str

( E
)

E F
. 
NotNull 
( 
) 
. 
MaximumLength 
( 
$num !
)! "
." #
WithMessage# .
(. /
$str/ _
)_ `
;` a
} 	
} 
} ◊
ÑD:\Real-Estate\RealEstate.Application\Features\CommercialCategories\Commands\CreateCommercialCategory\CreateCommercialCategoryDto.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) * 
CommercialCategories* >
.> ?
Commands? G
.G H$
CreateCommercialCategoryH `
{ 
public 

class '
CreateCommercialCategoryDto ,
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
string 
? 
CategoryName #
{$ %
get& )
;) *
set+ .
;. /
}0 1
} 
} ì
ÅD:\Real-Estate\RealEstate.Application\Features\CommercialCategories\Commands\DeleteCommercialCategory\DeleteCommercialCategory.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) * 
CommercialCategories* >
.> ?
Commands? G
.G H$
DeleteCommercialCategoryH `
{ 
public 

class $
DeleteCommercialCategory )
:* +
IRequest, 4
<4 5,
 DeleteCommercialCategoryResponse5 U
>U V
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
} 
}		 §
àD:\Real-Estate\RealEstate.Application\Features\CommercialCategories\Commands\DeleteCommercialCategory\DeleteCommercialCategoryHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) * 
CommercialCategories* >
.> ?
Commands? G
.G H$
DeleteCommercialCategoryH `
{ 
public 

class +
DeleteCommercialCategoryHandler 0
:1 2
IRequestHandler3 B
<B C$
DeleteCommercialCategoryC [
,[ \,
 DeleteCommercialCategoryResponse] }
>} ~
{ 
private 
readonly )
ICommercialCategoryRepository 6

repository7 A
;A B
public

 +
DeleteCommercialCategoryHandler

 .
(

. /)
ICommercialCategoryRepository

/ L

repository

M W
)

W X
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< ,
 DeleteCommercialCategoryResponse :
>: ;
Handle< B
(B C$
DeleteCommercialCategoryC [
request\ c
,c d
CancellationTokene v
cancellationToken	w à
)
à â
{ 	
var 
result 
= 
await 

repository )
.) *
DeleteAsync* 5
(5 6
request6 =
.= >
Id> @
)@ A
;A B
if 
( 
! 
result 
. 
	IsSuccess !
)! "
{ 
return 
new ,
 DeleteCommercialCategoryResponse ;
{ 
Success 
= 
false #
,# $
ValidationErrors $
=% &
new' *
List+ /
</ 0
string0 6
>6 7
{8 9
result: @
.@ A
ErrorA F
}G H
} 
; 
} 
return 
new ,
 DeleteCommercialCategoryResponse 7
{ 
Success 
= 
true 
} 
; 
} 	
}   
}!! «
âD:\Real-Estate\RealEstate.Application\Features\CommercialCategories\Commands\DeleteCommercialCategory\DeleteCommercialCategoryResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) * 
CommercialCategories* >
.> ?
Commands? G
.G H$
DeleteCommercialCategoryH `
{ 
public 

class ,
 DeleteCommercialCategoryResponse 1
:2 3
BaseResponse4 @
{ 
} 
} ä
àD:\Real-Estate\RealEstate.Application\Features\CommercialCategories\Commands\UpdateCommercialCategory\UpdateCommercialCategoryCommand.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) * 
CommercialCategories* >
.> ?
Commands? G
.G H$
UpdateCommercialCategoryH `
{ 
public 
class +
UpdateCommercialCategoryCommand -
:- .
IRequest/ 7
<7 83
'UpdateCommercialCategoryCommandResponse8 _
>_ `
{ 
public 
Guid	 
Id 
{ 
get 
; 
set 
; 
} 
public 
string	 
CategoryName 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
default- 4
!4 5
;5 6
}		 
}

 ó(
èD:\Real-Estate\RealEstate.Application\Features\CommercialCategories\Commands\UpdateCommercialCategory\UpdateCommercialCategoryCommandHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) * 
CommercialCategories* >
.> ?
Commands? G
.G H$
UpdateCommercialCategoryH `
{ 
public 
class 2
&UpdateCommercialCategoryCommandHandler 4
:4 5
IRequestHandler6 E
<E F+
UpdateCommercialCategoryCommandF e
,e f4
'UpdateCommercialCategoryCommandResponse	g é
>
é è
{ 
private 	
readonly
 )
ICommercialCategoryRepository 0

repository1 ;
;; <
public		 2
&UpdateCommercialCategoryCommandHandler			 /
(		/ 0)
ICommercialCategoryRepository		0 M

repository		N X
)		X Y
{

 
this 
. 

repository 
= 

repository 
;  
} 
public 
async	 
Task 
< 3
'UpdateCommercialCategoryCommandResponse ;
>; <
Handle= C
(C D+
UpdateCommercialCategoryCommandD c
requestd k
,k l
CancellationTokenm ~
cancellationToken	 ê
)
ê ë
{ 
var 
commercialCategory 
= 
await !

repository" ,
., -
FindByIdAsync- :
(: ;
request; B
.B C
IdC E
)E F
;F G
var 
	validator 
= 
new 4
(UpdateCommercialCategoryCommandValidator ?
(? @
)@ A
;A B
var 
validatorResult 
= 
await 
	validator (
.( )
ValidateAsync) 6
(6 7
request7 >
,> ?
cancellationToken@ Q
)Q R
;R S
if 
( 
! 
validatorResult 
. 
IsValid 
)  
{ 
return 

new 3
'UpdateCommercialCategoryCommandResponse 6
{ 
Success 
= 
false 
, 
ValidationErrors 
= 
validatorResult '
.' (
Errors( .
.. /
Select/ 5
(5 6
e6 7
=>8 :
e; <
.< =
ErrorMessage= I
)I J
.J K
ToListK Q
(Q R
)R S
} 
; 
} 
if 
( 
! 
commercialCategory 
. 
	IsSuccess $
)$ %
{ 
return 

new 3
'UpdateCommercialCategoryCommandResponse 6
{ 
Success   
=   
false   
,   
ValidationErrors!! 
=!! 
new!! 
List!!  
<!!  !
string!!! '
>!!' (
(!!( )
)!!) *
{!!+ ,
commercialCategory!!- ?
.!!? @
Error!!@ E
}!!F G
}"" 
;"" 
}## 
commercialCategory%% 
.%% 
Value%% 
.%% 
AttachCategoryName%% .
(%%. /
request%%/ 6
.%%6 7
CategoryName%%7 C
)%%C D
;%%D E
var&& %
updatedCommercialCategory&&  
=&&! "
await&&# (

repository&&) 3
.&&3 4
UpdateAsync&&4 ?
(&&? @
commercialCategory&&@ R
.&&R S
Value&&S X
)&&X Y
;&&Y Z
if(( 
((( 
!(( %
updatedCommercialCategory(( !
.((! "
	IsSuccess((" +
)((+ ,
{)) 
return** 

new** 3
'UpdateCommercialCategoryCommandResponse** 6
{++ 
Success,, 
=,, 
false,, 
,,, 
ValidationErrors-- 
=-- 
new-- 
List--  
<--  !
string--! '
>--' (
(--( )
)--) *
{--+ ,%
updatedCommercialCategory--- F
.--F G
Error--G L
}--M N
}.. 
;.. 
}// 
return11 	
new11
 3
'UpdateCommercialCategoryCommandResponse11 5
{22 
Success33 
=33 
true33 
,33 
CommercialCategory44 
=44 
new44 '
UpdateCommercialCategoryDto44 8
{55 
CategoryName66 
=66 %
updatedCommercialCategory66 -
.66- .
Value66. 3
.663 4
CategoryName664 @
}77 
}88 
;88 
}99 
}:: 
};; ‘
êD:\Real-Estate\RealEstate.Application\Features\CommercialCategories\Commands\UpdateCommercialCategory\UpdateCommercialCategoryCommandResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) * 
CommercialCategories* >
.> ?
Commands? G
.G H$
UpdateCommercialCategoryH `
{ 
public 
class 3
'UpdateCommercialCategoryCommandResponse 5
:5 6
BaseResponse7 C
{ 
public 3
'UpdateCommercialCategoryCommandResponse	 0
(0 1
)1 2
:2 3
base4 8
(8 9
)9 :
{ 
}		 
public

 '
UpdateCommercialCategoryDto

	 $
CommercialCategory

% 7
{

8 9
get

: =
;

= >
set

? B
;

B C
}

D E
} 
} ø
ëD:\Real-Estate\RealEstate.Application\Features\CommercialCategories\Commands\UpdateCommercialCategory\UpdateCommercialCategoryCommandValidator.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) * 
CommercialCategories* >
.> ?
Commands? G
.G H$
UpdateCommercialCategoryH `
{ 
public 
class 4
(UpdateCommercialCategoryCommandValidator 6
:6 7
AbstractValidator8 I
<I J+
UpdateCommercialCategoryCommandJ i
>i j
{ 
public 4
(UpdateCommercialCategoryCommandValidator	 1
(1 2
)2 3
{ 
RuleFor		 

(		
 
p		 
=>		 
p		 
.		 
Id		 
)		 
.

 
NotEmpty

 
(

 
)

 
.

 
WithMessage

 
(

 
$str

 9
)

9 :
. 
NotNull 
( 
) 
. 
WithMessage 
( 
$str 8
)8 9
;9 :
RuleFor 

(
 
p 
=> 
p 
. 
CategoryName 
) 
. 
NotEmpty 
( 
) 
. 
WithMessage 
( 
$str 9
)9 :
. 
NotNull 
( 
) 
. 
WithMessage 
( 
$str 8
)8 9
;9 :
} 
} 
} √
ÑD:\Real-Estate\RealEstate.Application\Features\CommercialCategories\Commands\UpdateCommercialCategory\UpdateCommercialCategoryDto.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) * 
CommercialCategories* >
.> ?
Commands? G
.G H$
UpdateCommercialCategoryH `
{ 
public 
class '
UpdateCommercialCategoryDto )
{ 
public 
string	 
? 
CategoryName 
{ 
get  #
;# $
set% (
;( )
}* +
} 
} ≠
dD:\Real-Estate\RealEstate.Application\Features\CommercialCategories\Queries\CommercialCategoryDto.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) * 
CommercialCategories* >
.> ?
Queries? F
{ 
public 

class !
CommercialCategoryDto &
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
string 
CategoryName "
{# $
get% (
;( )
set* -
;- .
}/ 0
=1 2
default3 :
!: ;
;; <
} 
} Ë
uD:\Real-Estate\RealEstate.Application\Features\CommercialCategories\Queries\GetAll\GetAllCommercialCategoriesQuery.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) * 
CommercialCategories* >
.> ?
Queries? F
.F G
GetAllG M
{ 
public 

class +
GetAllCommercialCategoriesQuery 0
:1 2
IRequest3 ;
<; <.
"GetAllCommercialCategoriesResponse< ^
>^ _
{ 
} 
} ›
|D:\Real-Estate\RealEstate.Application\Features\CommercialCategories\Queries\GetAll\GetAllCommercialCategoriesQueryHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) * 
CommercialCategories* >
.> ?
Queries? F
.F G
GetAllG M
{ 
public 

class 2
&GetAllCommercialCategoriesQueryHandler 7
:8 9
IRequestHandler: I
<I J+
GetAllCommercialCategoriesQueryJ i
,i j/
"GetAllCommercialCategoriesResponse	k ç
>
ç é
{ 
private 
readonly )
ICommercialCategoryRepository 6

repository7 A
;A B
public

 2
&GetAllCommercialCategoriesQueryHandler

 5
(

5 6)
ICommercialCategoryRepository

6 S

repository

T ^
)

^ _
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< .
"GetAllCommercialCategoriesResponse <
>< =
Handle> D
(D E+
GetAllCommercialCategoriesQueryE d
requeste l
,l m
CancellationTokenn 
cancellationToken
Ä ë
)
ë í
{ 	.
"GetAllCommercialCategoriesResponse .
response/ 7
=8 9
new: =
(= >
)> ?
;? @
var 
result 
= 
await 

repository )
.) *
GetAllAsync* 5
(5 6
)6 7
;7 8
if 
( 
result 
. 
	IsSuccess  
)  !
{ 
response 
.  
CommercialCategories -
=. /
result0 6
.6 7
Value7 <
.< =
Select= C
(C D
commercialCategoryD V
=>W Y
newZ ]!
CommercialCategoryDto^ s
{ 
Id 
= 
commercialCategory +
.+ ,
Id, .
,. /
CategoryName  
=! "
commercialCategory# 5
.5 6
CategoryName6 B
} 
) 
. 
ToList 
( 
) 
; 
} 
return 
response 
; 
} 	
} 
} ‚
xD:\Real-Estate\RealEstate.Application\Features\CommercialCategories\Queries\GetAll\GetAllCommercialCategoriesResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) * 
CommercialCategories* >
.> ?
Queries? F
.F G
GetAllG M
{ 
public 

class .
"GetAllCommercialCategoriesResponse 3
{ 
public 
List 
< !
CommercialCategoryDto )
>) * 
CommercialCategories+ ?
{@ A
getB E
;E F
setG J
;J K
}L M
} 
} ç
uD:\Real-Estate\RealEstate.Application\Features\CommercialCategories\Queries\GetById\GetByIdCommercialCategoryQuery.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) * 
CommercialCategories* >
.> ?
Queries? F
.F G
GetByIdG N
{ 
public 

record *
GetByIdCommercialCategoryQuery 0
(0 1
Guid1 5
Id6 8
)8 9
:: ;
IRequest< D
<D E!
CommercialCategoryDtoE Z
>Z [
;[ \
} Õ
|D:\Real-Estate\RealEstate.Application\Features\CommercialCategories\Queries\GetById\GetByIdCommercialCategoryQueryHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) * 
CommercialCategories* >
.> ?
Queries? F
.F G
GetByIdG N
{ 
public 

class 1
%GetByIdCommercialCategoryQueryHandler 6
:7 8
IRequestHandler9 H
<H I*
GetByIdCommercialCategoryQueryI g
,g h!
CommercialCategoryDtoi ~
>~ 
{ 
private 
readonly )
ICommercialCategoryRepository 6

repository7 A
;A B
public

 1
%GetByIdCommercialCategoryQueryHandler

 4
(

4 5)
ICommercialCategoryRepository

5 R

repository

S ]
)

] ^
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< !
CommercialCategoryDto /
>/ 0
Handle1 7
(7 8*
GetByIdCommercialCategoryQuery8 V
requestW ^
,^ _
CancellationToken` q
cancellationToken	r É
)
É Ñ
{ 	
var 
commercialCategory "
=# $
await% *

repository+ 5
.5 6
FindByIdAsync6 C
(C D
requestD K
.K L
IdL N
)N O
;O P
if 
( 
commercialCategory "
." #
	IsSuccess# ,
), -
{ 
return 
new !
CommercialCategoryDto 0
{ 
Id 
= 
commercialCategory +
.+ ,
Value, 1
.1 2
Id2 4
,4 5
CategoryName  
=! "
commercialCategory# 5
.5 6
Value6 ;
.; <
CategoryName< H
} 
; 
} 
return 
new !
CommercialCategoryDto ,
(, -
)- .
;. /
} 	
} 
} ö
áD:\Real-Estate\RealEstate.Application\Features\CommercialSpecifics\Commands\CreateCommercialSpecific\CreateCommercialSpecificCommand.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
CommercialSpecifics* =
.= >
Commands> F
.F G$
CreateCommercialSpecificG _
{ 
public 
class +
CreateCommercialSpecificCommand -
:. /
IRequest0 8
<8 93
'CreateCommercialSpecificCommandResponse9 `
>` a
{ 
public 
string 
SpecificName "
{# $
get% (
;( )
set* -
;- .
}/ 0
=1 2
default3 :
!: ;
;; <
public 
Guid  
CommercialCategoryId (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
}		 
}

 °$
éD:\Real-Estate\RealEstate.Application\Features\CommercialSpecifics\Commands\CreateCommercialSpecific\CreateCommercialSpecificCommandHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
CommercialSpecifics* =
.= >
Commands> F
.F G$
CreateCommercialSpecificG _
{ 
public 
class 2
&CreateCommercialSpecificCommandHandler 4
:5 6
IRequestHandler7 F
<F G+
CreateCommercialSpecificCommandG f
,f g4
'CreateCommercialSpecificCommandResponse	h è
>
è ê
{ 
private		 
readonly		 )
ICommercialSpecificRepository		 6

repository		7 A
;		A B
public 2
&CreateCommercialSpecificCommandHandler 5
(5 6)
ICommercialSpecificRepository6 S

repositoryT ^
)^ _
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< 3
'CreateCommercialSpecificCommandResponse A
>A B
HandleC I
(I J+
CreateCommercialSpecificCommandJ i
requestj q
,q r
CancellationToken	s Ñ
cancellationToken
Ö ñ
)
ñ ó
{ 	
var 
	validator 
= 
new 4
(CreateCommercialSpecificCommandValidator  H
(H I
)I J
;J K
var 
validatorResult 
=  !
await" '
	validator( 1
.1 2
ValidateAsync2 ?
(? @
request@ G
,G H
cancellationTokenI Z
)Z [
;[ \
if 
( 
! 
validatorResult  
.  !
IsValid! (
)( )
{ 
return 
new 3
'CreateCommercialSpecificCommandResponse B
{ 
Success 
= 
false #
,# $
ValidationErrors $
=% &
validatorResult' 6
.6 7
Errors7 =
.= >
Select> D
(D E
eE F
=>G I
eJ K
.K L
ErrorMessageL X
)X Y
.Y Z
ToListZ `
(` a
)a b
} 
; 
} 
var 
commercialSpecific "
=# $
CommercialSpecific% 7
.7 8
Create8 >
(> ?
request? F
.F G
SpecificNameG S
,S T
requestT [
.[ \ 
CommercialCategoryId\ p
)p q
;q r
if   
(   
!   
commercialSpecific   "
.  " #
	IsSuccess  # ,
)  , -
{!! 
return"" 
new"" 3
'CreateCommercialSpecificCommandResponse"" B
{## 
Success$$ 
=$$ 
false$$ #
,$$# $
ValidationErrors%% $
=%%% &
new%%' *
List%%+ /
<%%/ 0
string%%0 6
>%%6 7
(%%7 8
)%%8 9
{%%: ;
commercialSpecific%%< N
.%%N O
Error%%O T
}%%U V
}&& 
;&& 
}'' 
await)) 

repository)) 
.)) 
AddAsync)) %
())% &
commercialSpecific))& 8
.))8 9
Value))9 >
)))> ?
;))? @
return++ 
new++ 3
'CreateCommercialSpecificCommandResponse++ >
{,, 
Success-- 
=-- 
true-- 
,-- 
CommercialSpecific.. "
=..# $
new..% ('
CreateCommercialSpecificDto..) D
{//  
CommercialSpecificId11 (
=11) *
commercialSpecific11+ =
.11= >
Value11> C
.11C D 
CommercialSpecificId11D X
,11X Y
SpecificName22  
=22! "
commercialSpecific22# 5
.225 6
Value226 ;
.22; <
SpecificName22< H
,22H I 
CommercialCategoryId33 (
=33) *
commercialSpecific33+ =
.33= >
Value33> C
.33C D 
CommercialCategoryId33D X
}55 
}66 
;66 
}77 	
}88 
}99 “
èD:\Real-Estate\RealEstate.Application\Features\CommercialSpecifics\Commands\CreateCommercialSpecific\CreateCommercialSpecificCommandResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
CommercialSpecifics* =
.= >
Commands> F
.F G$
CreateCommercialSpecificG _
{ 
public 

class 3
'CreateCommercialSpecificCommandResponse 8
:9 :
BaseResponse; G
{ 
public 3
'CreateCommercialSpecificCommandResponse 6
(6 7
)7 8
: 
base 
( 
) 
{		 	
}

 	
public '
CreateCommercialSpecificDto *
CommercialSpecific+ =
{> ?
getA D
;D E
setF I
;I J
}K L
} 
} ƒ
êD:\Real-Estate\RealEstate.Application\Features\CommercialSpecifics\Commands\CreateCommercialSpecific\CreateCommercialSpecificCommandValidator.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
CommercialSpecifics* =
.= >
Commands> F
.F G$
CreateCommercialSpecificG _
{ 
public 

class 4
(CreateCommercialSpecificCommandValidator 9
:: ;
AbstractValidator< M
<M N+
CreateCommercialSpecificCommandN m
>m n
{ 
public 4
(CreateCommercialSpecificCommandValidator 7
(7 8
)8 9
{ 	
RuleFor		 
(		 
x		 
=>		 
x		 
.		 
SpecificName		 '
)		' (
.

 
NotEmpty

 
(

 
)

 
. 
WithMessage 
( 
$str 4
)4 5
. 
NotNull 
( 
) 
. 
WithMessage 
( 
$str 4
)4 5
. 
Must 
( 
specificName 
=> !
!" #
string# )
.) *
IsNullOrWhiteSpace* <
(< =
specificName= I
)I J
)J K
. 
WithMessage 
( 
$str 4
)4 5
;5 6
} 	
} 
} ç
ÉD:\Real-Estate\RealEstate.Application\Features\CommercialSpecifics\Commands\CreateCommercialSpecific\CreateCommercialSpecificDto.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
CommercialSpecifics* =
.= >
Commands> F
.F G$
CreateCommercialSpecificG _
{ 
public 
class '
CreateCommercialSpecificDto )
{ 
public 
Guid  
CommercialSpecificId (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
string 
? 
SpecificName #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
Guid  
CommercialCategoryId (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
} 
}		 £
ÄD:\Real-Estate\RealEstate.Application\Features\CommercialSpecifics\Commands\DeleteCommercialSpecific\DeleteCommercialSpecific.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
CommercialSpecifics* =
.= >
Commands> F
.F G$
DeleteCommercialSpecificG _
{ 
public 

class $
DeleteCommercialSpecific )
:* +
IRequest, 4
<4 5,
 DeleteCommercialSpecificResponse5 U
>U V
{ 
public 
Guid  
CommercialSpecificId (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
} 
}		 ¥
áD:\Real-Estate\RealEstate.Application\Features\CommercialSpecifics\Commands\DeleteCommercialSpecific\DeleteCommercialSpecificHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
CommercialSpecifics* =
.= >
Commands> F
.F G$
DeleteCommercialSpecificG _
{ 
public 

class +
DeleteCommercialSpecificHandler 0
:1 2
IRequestHandler3 B
<B C$
DeleteCommercialSpecificC [
,[ \,
 DeleteCommercialSpecificResponse] }
>} ~
{ 
private 
readonly )
ICommercialSpecificRepository 6

repository7 A
;A B
public

 +
DeleteCommercialSpecificHandler

 .
(

. /)
ICommercialSpecificRepository

/ L

repository

M W
)

W X
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< ,
 DeleteCommercialSpecificResponse :
>: ;
Handle< B
(B C$
DeleteCommercialSpecificC [
request\ c
,c d
CancellationTokene v
cancellationToken	w à
)
à â
{ 	
var 
result 
= 
await 

repository )
.) *
DeleteAsync* 5
(5 6
request6 =
.= > 
CommercialSpecificId> R
)R S
;S T
if 
( 
! 
result 
. 
	IsSuccess  
)  !
{ 
return 
new ,
 DeleteCommercialSpecificResponse ;
{ 
Success 
= 
false #
,# $
ValidationErrors $
=% &
new' *
List+ /
</ 0
string0 6
>6 7
{8 9
result: @
.@ A
ErrorA F
}G H
} 
; 
} 
return 
new ,
 DeleteCommercialSpecificResponse 7
{ 
Success 
= 
true 
} 
; 
} 	
}   
}!! ≈
àD:\Real-Estate\RealEstate.Application\Features\CommercialSpecifics\Commands\DeleteCommercialSpecific\DeleteCommercialSpecificResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
CommercialSpecifics* =
.= >
Commands> F
.F G$
DeleteCommercialSpecificG _
{ 
public 

class ,
 DeleteCommercialSpecificResponse 1
:2 3
BaseResponse4 @
{ 
} 
} Æ	
áD:\Real-Estate\RealEstate.Application\Features\CommercialSpecifics\Commands\UpdateCommercialSpecific\UpdateCommercialSpecificCommand.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
CommercialSpecifics* =
.= >
Commands> F
.F G$
UpdateCommercialSpecificG _
{ 
public 
class +
UpdateCommercialSpecificCommand -
:- .
IRequest/ 7
<7 83
'UpdateCommercialSpecificCommandResponse8 _
>_ `
{ 
public 
Guid	 
Id 
{ 
get 
; 
set 
; 
} 
public 
string	 
SpecificName 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
default- 4
!4 5
;5 6
public		 
Guid			  
CommercialCategoryId		 "
{		# $
get		% (
;		( )
set		* -
;		- .
}		/ 0
}

 
} ª+
éD:\Real-Estate\RealEstate.Application\Features\CommercialSpecifics\Commands\UpdateCommercialSpecific\UpdateCommercialSpecificCommandHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
CommercialSpecifics* =
.= >
Commands> F
.F G$
UpdateCommercialSpecificG _
{ 
public 
class 2
&UpdateCommercialSpecificCommandHandler 4
:4 5
IRequestHandler6 E
<E F+
UpdateCommercialSpecificCommandF e
,e f4
'UpdateCommercialSpecificCommandResponse	f ç
>
ç é
{ 
private 	
readonly
 )
ICommercialSpecificRepository 0

repository1 ;
;; <
public		 2
&UpdateCommercialSpecificCommandHandler			 /
(		/ 0)
ICommercialSpecificRepository		0 M

repository		N X
)		X Y
{

 
this 
. 

repository 
= 

repository 
;  
} 
public 
async	 
Task 
< 3
'UpdateCommercialSpecificCommandResponse ;
>; <
Handle= C
(C D+
UpdateCommercialSpecificCommandD c
requestd k
,k l
CancellationTokenm ~
cancellationToken	 ê
)
ê ë
{ 
var 
commercialSpecific 
= 
await !

repository" ,
., -
FindByIdAsync- :
(: ;
request; B
.B C
IdC E
)E F
;F G
var 
	validator 
= 
new 4
(UpdateCommercialSpecificCommandValidator ?
(? @
)@ A
;A B
var 
validatorResult 
= 
await 
	validator (
.( )
ValidateAsync) 6
(6 7
request7 >
,> ?
cancellationToken@ Q
)Q R
;R S
if 
( 
! 
validatorResult 
. 
IsValid 
)  
{ 
return 

new 3
'UpdateCommercialSpecificCommandResponse 6
{ 
Success 
= 
false 
, 
ValidationErrors 
= 
validatorResult '
.' (
Errors( .
.. /
Select/ 5
(5 6
e6 7
=>8 :
e; <
.< =
ErrorMessage= I
)I J
.J K
ToListK Q
(Q R
)R S
} 
; 
} 
if 
( 
! 
commercialSpecific 
. 
	IsSuccess $
)$ %
{ 
return 

new 3
'UpdateCommercialSpecificCommandResponse 6
{   
Success!! 
=!! 
false!! 
,!! 
ValidationErrors"" 
="" 
new"" 
List""  
<""  !
string""! '
>""' (
(""( )
)"") *
{""+ ,
commercialSpecific""- ?
.""? @
Error""@ E
}""F G
}## 
;## 
}$$ 
commercialSpecific&& 
.&& 
Value&& 
.&& 
AttachSpecificName&& .
(&&. /
request&&/ 6
.&&6 7
SpecificName&&7 C
)&&C D
;&&D E
commercialSpecific'' 
.'' 
Value'' 
.'' &
AttachCommercialCategoryId'' 6
(''6 7
request''7 >
.''> ? 
CommercialCategoryId''? S
)''S T
;''T U
var(( %
updatedCommercialSpecific((  
=((! "
await((# (

repository(() 3
.((3 4
UpdateAsync((4 ?
(((? @
commercialSpecific((@ R
.((R S
Value((S X
)((X Y
;((Y Z
if** 
(** 
!** %
updatedCommercialSpecific** !
.**! "
	IsSuccess**" +
)**+ ,
{++ 
return,, 

new,, 3
'UpdateCommercialSpecificCommandResponse,, 6
{-- 
Success.. 
=.. 
false.. 
,.. 
ValidationErrors// 
=// 
new// 
List//  
<//  !
string//! '
>//' (
(//( )
)//) *
{//+ ,%
updatedCommercialSpecific//- F
.//F G
Error//G L
}//M N
}00 
;00 
}11 
return33 	
new33
 3
'UpdateCommercialSpecificCommandResponse33 5
{44 
Success55 
=55 
true55 
,55 
CommercialSpecific66 
=66 
new66 '
UpdateCommercialSpecificDto66 8
{77 
SpecificName88 
=88 %
updatedCommercialSpecific88 -
.88- .
Value88. 3
.883 4
SpecificName884 @
,88@ A 
CommercialCategoryId99 
=99 %
updatedCommercialSpecific99 5
.995 6
Value996 ;
.99; < 
CommercialCategoryId99< P
}:: 
};; 
;;; 
}== 
}>> 
}?? “
èD:\Real-Estate\RealEstate.Application\Features\CommercialSpecifics\Commands\UpdateCommercialSpecific\UpdateCommercialSpecificCommandResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
CommercialSpecifics* =
.= >
Commands> F
.F G$
UpdateCommercialSpecificG _
{ 
public 
class 3
'UpdateCommercialSpecificCommandResponse 5
:5 6
BaseResponse7 C
{ 
public 3
'UpdateCommercialSpecificCommandResponse	 0
(0 1
)1 2
:2 3
base4 8
(8 9
)9 :
{ 
}		 
public

 '
UpdateCommercialSpecificDto

	 $
CommercialSpecific

% 7
{

8 9
get

: =
;

= >
set

? B
;

B C
}

D E
} 
} ˘
êD:\Real-Estate\RealEstate.Application\Features\CommercialSpecifics\Commands\UpdateCommercialSpecific\UpdateCommercialSpecificCommandValidator.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
CommercialSpecifics* =
.= >
Commands> F
.F G$
UpdateCommercialSpecificG _
{ 
public 
class 4
(UpdateCommercialSpecificCommandValidator 6
:6 7
AbstractValidator8 I
<I J+
UpdateCommercialSpecificCommandJ i
>i j
{ 
public 4
(UpdateCommercialSpecificCommandValidator	 1
(1 2
)2 3
{ 
RuleFor		 

(		
 
p		 
=>		 
p		 
.		 
Id		 
)		 
.

 
NotEmpty

 
(

 
)

 
.

 
WithMessage

 
(

 
$str

 9
)

9 :
. 
NotNull 
( 
) 
. 
NotEqual 
( 
Guid 
. 
Empty 
) 
; 
RuleFor 

(
 
p 
=> 
p 
. 
SpecificName 
) 
. 
NotEmpty 
( 
) 
. 
WithMessage 
( 
$str 9
)9 :
. 
NotNull 
( 
) 
; 
RuleFor 

(
 
p 
=> 
p 
.  
CommercialCategoryId &
)& '
. 
NotEmpty 
( 
) 
. 
WithMessage 
( 
$str 9
)9 :
. 
NotNull 
( 
) 
. 
NotEqual 
( 
Guid 
. 
Empty 
) 
; 
} 
} 
} Á
ÉD:\Real-Estate\RealEstate.Application\Features\CommercialSpecifics\Commands\UpdateCommercialSpecific\UpdateCommercialSpecificDto.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
CommercialSpecifics* =
.= >
Commands> F
.F G$
UpdateCommercialSpecificG _
{ 
public 
class '
UpdateCommercialSpecificDto )
{ 
public 
string	 
? 
SpecificName 
{ 
get  #
;# $
set% (
;( )
}* +
public 
Guid	  
CommercialCategoryId "
{# $
get% (
;( )
set* -
;- .
}/ 0
} 
} „
cD:\Real-Estate\RealEstate.Application\Features\CommercialSpecifics\Queries\CommercialSpecificDto.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
CommercialSpecifics* =
.= >
Queries> E
{ 
public 

class !
CommercialSpecificDto &
{ 
public 
Guid  
CommercialSpecificId (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
string 
SpecificName "
{# $
get% (
;( )
set* -
;- .
}/ 0
=1 2
default3 :
!: ;
;; <
public 
Guid  
CommercialCategoryId (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
} 
}		 „
sD:\Real-Estate\RealEstate.Application\Features\CommercialSpecifics\Queries\GetAll\GetAllCommercialSpecificsQuery.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
CommercialSpecifics* =
.= >
Queries> E
.E F
GetAllF L
{ 
public 

class *
GetAllCommercialSpecificsQuery /
:0 1
IRequest2 :
<: ;-
!GetAllCommercialSpecificsResponse; \
>\ ]
{ 
} 
} Ü
zD:\Real-Estate\RealEstate.Application\Features\CommercialSpecifics\Queries\GetAll\GetAllCommercialSpecificsQueryHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
CommercialSpecifics* =
.= >
Queries> E
.E F
GetAllF L
{ 
public 
class 1
%GetAllCommercialSpecificsQueryHandler 3
:4 5
IRequestHandler6 E
<E F*
GetAllCommercialSpecificsQueryF d
,d e.
!GetAllCommercialSpecificsResponse	f á
>
á à
{ 
private 
readonly )
ICommercialSpecificRepository 6

repository7 A
;A B
public

 1
%GetAllCommercialSpecificsQueryHandler

 4
(

4 5)
ICommercialSpecificRepository

5 R

repository

S ]
)

] ^
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< -
!GetAllCommercialSpecificsResponse ;
>; <
Handle= C
(C D*
GetAllCommercialSpecificsQueryD b
requestc j
,j k
CancellationTokenl }
cancellationToken	~ è
)
è ê
{ 	-
!GetAllCommercialSpecificsResponse -
response. 6
=7 8
new9 <
(< =
)= >
;> ?
var 
result 
= 
await 

repository )
.) *
GetAllAsync* 5
(5 6
)6 7
;7 8
if 
( 
result 
. 
	IsSuccess  
)  !
{ 
response 
. 
CommercialSpecifics ,
=- .
result/ 5
.5 6
Value6 ;
.; <
Select< B
(B C
commercialSpecificC U
=>V X
newY \!
CommercialSpecificDto] r
{  
CommercialSpecificId (
=) *
commercialSpecific+ =
.= > 
CommercialSpecificId> R
,R S
SpecificName  
=! "
commercialSpecific# 5
.5 6
SpecificName6 B
,B C 
CommercialCategoryId (
=) *
commercialSpecific+ =
.= > 
CommercialCategoryId> R
} 
) 
. 
ToList 
( 
) 
; 
} 
return 
response 
; 
} 	
} 
}   ›
vD:\Real-Estate\RealEstate.Application\Features\CommercialSpecifics\Queries\GetAll\GetAllCommercialSpecificsResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
CommercialSpecifics* =
.= >
Queries> E
.E F
GetAllF L
{ 
public 

class -
!GetAllCommercialSpecificsResponse 2
{ 
public 
List 
< !
CommercialSpecificDto )
>) *
CommercialSpecifics+ >
{? @
getA D
;D E
setF I
;I J
}K L
} 
} ù
tD:\Real-Estate\RealEstate.Application\Features\CommercialSpecifics\Queries\GetById\GetByIdCommercialSpecificQuery.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
CommercialSpecifics* =
.= >
Queries> E
.E F
GetByIdF M
{ 
public 

record *
GetByIdCommercialSpecificQuery 0
(0 1
Guid1 5 
CommercialSpecificId6 J
)J K
:L M
IRequestN V
<V W!
CommercialSpecificDtoW l
>l m
;m n
} ¥
{D:\Real-Estate\RealEstate.Application\Features\CommercialSpecifics\Queries\GetById\GetByIdCommercialSpecificQueryHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
CommercialSpecifics* =
.= >
Queries> E
.E F
GetByIdF M
{ 
public 

class 1
%GetByIdCommercialSpecificQueryHandler 6
:7 8
IRequestHandler9 H
<H I*
GetByIdCommercialSpecificQueryI g
,g h!
CommercialSpecificDtoi ~
>~ 
{ 
private 
readonly )
ICommercialSpecificRepository 6

repository7 A
;A B
public

 1
%GetByIdCommercialSpecificQueryHandler

 4
(

4 5)
ICommercialSpecificRepository

5 R

repository

S ]
)

] ^
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< !
CommercialSpecificDto /
>/ 0
Handle1 7
(7 8*
GetByIdCommercialSpecificQuery8 V
requestW ^
,^ _
CancellationToken` q
cancellationToken	r É
)
É Ñ
{ 	
var 
commercialSpecific "
=# $
await% *

repository+ 5
.5 6
FindByIdAsync6 C
(C D
requestD K
.K L 
CommercialSpecificIdL `
)` a
;a b
if 
( 
commercialSpecific "
." #
	IsSuccess# ,
), -
{ 
return 
new !
CommercialSpecificDto 0
{  
CommercialSpecificId (
=) *
commercialSpecific+ =
.= >
Value> C
.C D 
CommercialSpecificIdD X
,X Y
SpecificName  
=! "
commercialSpecific# 5
.5 6
Value6 ;
.; <
SpecificName< H
,H I 
CommercialCategoryId (
=) *
commercialSpecific+ =
.= >
Value> C
.C D 
CommercialCategoryIdD X
} 
; 
} 
return 
new !
CommercialSpecificDto ,
(, -
)- .
;. /
} 	
} 
} ¯
oD:\Real-Estate\RealEstate.Application\Features\Commercials\Commands\CreateCommercial\CreateCommercialCommand.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Commercials* 5
.5 6
Commands6 >
.> ?
CreateCommercial? O
{ 
public 
class #
CreateCommercialCommand %
:& '
IRequest( 0
<0 1+
CreateCommercialCommandResponse1 P
>P Q
{ 
public 
string 
UserId 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
default- 4
!4 5
;5 6
public 
string 
	TitlePost 
{  !
get" %
;% &
set' *
;* +
}, -
=. /
default0 7
!7 8
;8 9
public		 
double		 
Price		 
{		 
get		 !
;		! "
set		# &
;		& '
}		( )
=		* +
default		, 3
!		3 4
;		4 5
public

 
Guid

 
	AddressId

 
{

 
get

  #
;

# $
set

% (
;

( )
}

* +
=

, -
default

. 5
!

5 6
;

6 7
public 
bool 
	OfferType 
{ 
get  #
;# $
set% (
;( )
}* +
=, -
default. 5
!5 6
;6 7
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
default2 9
!9 :
;: ;
public 
Guid  
CommercialSpecificId (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
double 
UsefulSurface #
{$ %
get& )
;) *
set+ .
;. /
}0 1
=2 3
default4 ;
!; <
;< =
public 
DateTime 
Disponibility %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
=4 5
default6 =
!= >
;> ?
} 
} ”.
vD:\Real-Estate\RealEstate.Application\Features\Commercials\Commands\CreateCommercial\CreateCommercialCommandHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Commercials* 5
.5 6
Commands6 >
.> ?
CreateCommercial? O
{ 
public 
class *
CreateCommercialCommandHandler ,
:- .
IRequestHandler/ >
<> ?#
CreateCommercialCommand? V
,V W+
CreateCommercialCommandResponseX w
>w x
{ 
private		 
readonly		 !
ICommercialRepository		 .

repository		/ 9
;		9 :
public

 *
CreateCommercialCommandHandler

 -
(

- .!
ICommercialRepository

. C

repository

D N
)

N O
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< +
CreateCommercialCommandResponse 9
>9 :
Handle; A
(A B#
CreateCommercialCommandB Y
requestZ a
,a b
CancellationTokenc t
cancellationToken	u Ü
)
Ü á
{ 	
var 
	validator 
= 
new ,
 CreateCommercialCommandValidator  @
(@ A
)A B
;B C
var 
validatorResult 
=  !
await" '
	validator( 1
.1 2
ValidateAsync2 ?
(? @
request@ G
,G H
cancellationTokenI Z
)Z [
;[ \
if 
( 
! 
validatorResult  
.  !
IsValid! (
)( )
{ 
return 
new +
CreateCommercialCommandResponse :
{ 
Success 
= 
false #
,# $
ValidationErrors $
=% &
validatorResult' 6
.6 7
Errors7 =
.= >
Select> D
(D E
eE F
=>G I
eJ K
.K L
ErrorMessageL X
)X Y
.Y Z
ToListZ `
(` a
)a b
} 
; 
} 
var 

commercial 
= 

Commercial '
.' (
Create( .
(. /
request/ 6
.6 7
UserId7 =
,= >
request? F
.F G
	TitlePostG P
,P Q
requestR Y
.Y Z
PriceZ _
,_ `
requesta h
.h i
	AddressIdi r
,r s
requestt {
.{ |
	OfferType	| Ö
,
Ö Ü
request
á é
.
é è
Description
è ö
,
ö õ
request 
.  
CommercialSpecificId ,
,, -
request. 5
.5 6
UsefulSurface6 C
,C D
requestE L
.L M
DisponibilityM Z
)Z [
;[ \
if 
( 
! 

commercial 
. 
	IsSuccess %
)% &
{   
return!! 
new!! +
CreateCommercialCommandResponse!! :
{"" 
Success## 
=## 
false## #
,### $
ValidationErrors$$ $
=$$% &
new$$' *
List$$+ /
<$$/ 0
string$$0 6
>$$6 7
($$7 8
)$$8 9
{$$: ;

commercial$$< F
.$$F G
Error$$G L
}$$M N
}%% 
;%% 
}&& 
await(( 

repository(( 
.(( 
AddAsync(( %
(((% &

commercial((& 0
.((0 1
Value((1 6
)((6 7
;((7 8
return** 
new** +
CreateCommercialCommandResponse** 6
{++ 
Success,, 
=,, 
true,, 
,,, 

Commercial-- 
=-- 
new--  
CreateCommercialDto--! 4
{.. 

BasePostId// 
=//  

commercial//! +
.//+ ,
Value//, 1
.//1 2

BasePostId//2 <
,//< =
UserId00 
=00 

commercial00 '
.00' (
Value00( -
.00- .
UserId00. 4
,004 5
	TitlePost11 
=11 

commercial11  *
.11* +
Value11+ 0
.110 1
	TitlePost111 :
,11: ;
Price22 
=22 

commercial22 &
.22& '
Value22' ,
.22, -
Price22- 2
,222 3
	AddressId33 
=33 

commercial33  *
.33* +
Value33+ 0
.330 1
	AddressId331 :
,33: ;
	OfferType44 
=44 

commercial44  *
.44* +
Value44+ 0
.440 1
	OfferType441 :
,44: ;
Description55 
=55  !

commercial55" ,
.55, -
Value55- 2
.552 3
Description553 >
,55> ? 
CommercialSpecificId66 (
=66) *

commercial66+ 5
.665 6
Value666 ;
.66; < 
CommercialSpecificId66< P
,66P Q
UsefulSurface77 !
=77" #

commercial77$ .
.77. /
Value77/ 4
.774 5
UsefulSurface775 B
,77B C
Disponibility88 !
=88" #

commercial88$ .
.88. /
Value88/ 4
.884 5
Disponibility885 B
}99 
}:: 
;:: 
};; 	
}<< 
}== â
wD:\Real-Estate\RealEstate.Application\Features\Commercials\Commands\CreateCommercial\CreateCommercialCommandResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Commercials* 5
.5 6
Commands6 >
.> ?
CreateCommercial? O
{ 
public 

class +
CreateCommercialCommandResponse 0
:1 2
BaseResponse3 ?
{ 
public +
CreateCommercialCommandResponse .
(. /
)/ 0
:1 2
base3 7
(7 8
)8 9
{ 	
}		 	
public

 
CreateCommercialDto

 "

Commercial

# -
{

. /
get

0 3
;

3 4
set

5 8
;

8 9
}

9 :
} 
} ˛
xD:\Real-Estate\RealEstate.Application\Features\Commercials\Commands\CreateCommercial\CreateCommercialCommandValidator.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Commercials* 5
.5 6
Commands6 >
.> ?
CreateCommercial? O
{ 
public 

class ,
 CreateCommercialCommandValidator 1
:2 3
AbstractValidator4 E
<E F#
CreateCommercialCommandF ]
>] ^
{ 
public ,
 CreateCommercialCommandValidator /
(/ 0
)0 1
{ 	
RuleFor		 
(		 
p		 
=>		 
p		 
.		 
UserId		 !
)		! "
.

 
NotEmpty

 
(

 
)

 
.

 
WithMessage

 &
(

& '
$str

' D
)

D E
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
	TitlePost $
)$ %
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
Price  
)  !
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
. 
GreaterThan 
( 
$num 
) 
.  
WithMessage  +
(+ ,
$str, T
)T U
;U V
RuleFor 
( 
p 
=> 
p 
. 
	AddressId $
)$ %
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
	OfferType $
)$ %
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
Description &
)& '
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
.   
NotNull   
(   
)   
.!! 
MaximumLength!! 
(!! 
$num!! #
)!!# $
.!!$ %
WithMessage!!% 0
(!!0 1
$str!!1 b
)!!b c
;!!c d
RuleFor## 
(## 
x## 
=>## 
x## 
.##  
CommercialSpecificId## /
)##/ 0
.$$ 
NotNull$$ 
($$ 
)$$ 
.%% 
WithMessage%% 
(%% 
$str%% :
)%%: ;
;%%; <
RuleFor'' 
('' 
x'' 
=>'' 
x'' 
.'' 
UsefulSurface'' (
)''( )
.(( 
GreaterThan(( 
((( 
$num(( 
)(( 
.)) 
WithMessage)) 
()) 
$str)) D
)))D E
;))E F
}** 	
}++ 
},, 
kD:\Real-Estate\RealEstate.Application\Features\Commercials\Commands\CreateCommercial\CreateCommercialDto.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Commercials* 5
.5 6
Commands6 >
.> ?
CreateCommercial? O
{ 
public 
class 
CreateCommercialDto !
{ 
public 
Guid 

BasePostId 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
UserId 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
default- 4
!4 5
;5 6
public 
string 
	TitlePost 
{  !
get" %
;% &
set' *
;* +
}, -
=. /
default0 7
!7 8
;8 9
public 
double 
Price 
{ 
get !
;! "
set# &
;& '
}( )
public		 
Guid		 
	AddressId		 
{		 
get		  #
;		# $
set		% (
;		( )
}		* +
public

 
bool

 
	OfferType

 
{

 
get

  #
;

# $
set

% (
;

( )
}

* +
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
default2 9
!9 :
;: ;
public 
Guid  
CommercialSpecificId (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
double 
? 
UsefulSurface $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
DateTime 
? 
Disponibility &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
} 
} ‡
hD:\Real-Estate\RealEstate.Application\Features\Commercials\Commands\DeleteCommercial\DeleteCommercial.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Commercials* 5
.5 6
Commands6 >
.> ?
DeleteCommercial? O
{ 
public 

class 
DeleteCommercial !
:" #
IRequest$ ,
<, -$
DeleteCommercialResponse- E
>E F
{ 
public 
Guid 

BasePostId 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
}		 Æ
oD:\Real-Estate\RealEstate.Application\Features\Commercials\Commands\DeleteCommercial\DeleteCommercialHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Commercials* 5
.5 6
Commands6 >
.> ?
DeleteCommercial? O
{ 
public 

class #
DeleteCommercialHandler (
:) *
IRequestHandler+ :
<: ;
DeleteCommercial; K
,K L$
DeleteCommercialResponseM e
>e f
{ 
private 
readonly !
ICommercialRepository .

repository/ 9
;9 :
public

 #
DeleteCommercialHandler

 &
(

& '!
ICommercialRepository

' <

repository

= G
)

G H
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< $
DeleteCommercialResponse 2
>2 3
Handle4 :
(: ;
DeleteCommercial; K
requestL S
,S T
CancellationTokenU f
cancellationTokeng x
)x y
{ 	
var 
result 
= 
await 

repository )
.) *
DeleteAsync* 5
(5 6
request6 =
.= >

BasePostId> H
)H I
;I J
if 
( 
! 
result 
. 
	IsSuccess  
)  !
{ 
return 
new $
DeleteCommercialResponse 3
{ 
Success 
= 
false #
,# $
ValidationErrors $
=% &
new' *
List+ /
</ 0
string0 6
>6 7
{8 9
result: @
.@ A
ErrorA F
}G H
} 
; 
} 
return 
new $
DeleteCommercialResponse /
{ 
Success 
= 
true 
} 
; 
} 	
}   
}!! î
pD:\Real-Estate\RealEstate.Application\Features\Commercials\Commands\DeleteCommercial\DeleteCommercialResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Commercials* 5
.5 6
Commands6 >
.> ?
DeleteCommercial? O
{ 
public 

class $
DeleteCommercialResponse )
:* +
BaseResponse, 8
{ 
} 
} î
oD:\Real-Estate\RealEstate.Application\Features\Commercials\Commands\UpdateCommercial\UpdateCommercialCommand.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Commercials* 5
.5 6
Commands6 >
.> ?
UpdateCommercial? O
{ 
public 
class #
UpdateCommercialCommand %
:% &
IRequest' /
</ 0+
UpdateCommercialCommandResponse0 O
>O P
{ 
public 
Guid 

BasePostId 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
UserId 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
default- 4
!4 5
;5 6
public		 
string		 
	TitlePost		 
{		  !
get		" %
;		% &
set		' *
;		* +
}		, -
=		. /
default		0 7
!		7 8
;		8 9
public

 
double

 
Price

 
{

 
get

 !
;

! "
set

# &
;

& '
}

( )
=

* +
default

, 3
!

3 4
;

4 5
public 
Guid 
	AddressId 
{ 
get  #
;# $
set% (
;( )
}* +
=, -
default. 5
!5 6
;6 7
public 
bool 
	OfferType 
{ 
get  #
;# $
set% (
;( )
}* +
=, -
default. 5
!5 6
;6 7
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
default2 9
!9 :
;: ;
public 
double 
UsefulSurface #
{$ %
get& )
;) *
set+ .
;. /
}0 1
=2 3
default4 ;
!; <
;< =
public 
DateTime	 
Disponibility 
{  !
get" %
;% &
set' *
;* +
}, -
=. /
default0 7
!7 8
;8 9
public 
Guid	  
CommercialSpecificId "
{# $
get% (
;( )
set* -
;- .
}/ 0
} 
} À>
vD:\Real-Estate\RealEstate.Application\Features\Commercials\Commands\UpdateCommercial\UpdateCommercialCommandHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Commercials* 5
.5 6
Commands6 >
.> ?
UpdateCommercial? O
{ 
public 

class *
UpdateCommercialCommandHandler /
:/ 0
IRequestHandler1 @
<@ A#
UpdateCommercialCommandA X
,X Y+
UpdateCommercialCommandResponseZ y
>y z
{ 
private 	
readonly
 !
ICommercialRepository (

repository) 3
;3 4
public

 *
UpdateCommercialCommandHandler

	 '
(

' (!
ICommercialRepository

( =

repository

> H
)

H I
{ 
this 
. 

repository 
= 

repository 
;  
} 
public 
async	 
Task 
< +
UpdateCommercialCommandResponse 3
>3 4
Handle5 ;
(; <#
UpdateCommercialCommand< S
requestT [
,[ \
CancellationToken] n
cancellationToken	o Ä
)
Ä Å
{ 
var 

commercial 
= 
await 

repository $
.$ %
FindByIdAsync% 2
(2 3
request3 :
.: ;

BasePostId; E
)E F
;F G
var 
	validator 
= 
new ,
 UpdateCommercialCommandValidator 7
(7 8
)8 9
;9 :
var 
validatorResult 
= 
await 
	validator (
.( )
ValidateAsync) 6
(6 7
request7 >
,> ?
cancellationToken@ Q
)Q R
;R S
if 
( 
! 
validatorResult 
. 
IsValid 
)  
{ 
return 

new +
UpdateCommercialCommandResponse .
{ 
Success 
= 
false 
, 
ValidationErrors 
= 
validatorResult '
.' (
Errors( .
.. /
Select/ 5
(5 6
e6 7
=>8 :
e; <
.< =
ErrorMessage= I
)I J
.J K
ToListK Q
(Q R
)R S
} 
; 
} 
if 
( 
! 

commercial 
. 
	IsSuccess 
) 
{ 
return 

new +
UpdateCommercialCommandResponse .
{   
Success!! 
=!! 
false!! 
,!! 
ValidationErrors"" 
="" 
new"" 
List""  
<""  !
string""! '
>""' (
(""( )
)"") *
{""+ ,

commercial""- 7
.""7 8
Error""8 =
}""> ?
}## 
;## 
}$$ 

commercial&& 
.&& 
Value&& 
.&& 
AttachUsefulSurface&& '
(&&' (
request&&( /
.&&/ 0
UsefulSurface&&0 =
)&&= >
;&&> ?

commercial'' 
.'' 
Value'' 
.'' 
AttachDisponibility'' '
(''' (
request''( /
.''/ 0
Disponibility''0 =
)''= >
;''> ?

commercial(( 
.(( 
Value(( 
.(( &
AttachCommercialSpecificId(( .
(((. /
request((/ 6
.((6 7 
CommercialSpecificId((7 K
)((K L
;((L M

commercial)) 
.)) 
Value)) 
.)) 
AttachUserId))  
())  !
request))! (
.))( )
UserId))) /
)))/ 0
;))0 1

commercial** 
.** 
Value** 
.** 
AttachTitlePost** #
(**# $
request**$ +
.**+ ,
	TitlePost**, 5
)**5 6
;**6 7

commercial++ 
.++ 
Value++ 
.++ 
AttachPrice++ (
(++( )
request++) 0
.++0 1
Price++1 6
)++6 7
;++7 8

commercial,, 
.,, 
Value,, 
.,, 
AttachAddressId,, ,
(,,, -
request,,- 4
.,,4 5
	AddressId,,5 >
),,> ?
;,,? @

commercial-- 
.-- 
Value-- 
.-- 
AttachOfferType-- ,
(--, -
request--- 4
.--4 5
	OfferType--5 >
)--> ?
;--? @

commercial.. 
... 
Value.. 
... 
AttachDescription.. %
(..% &
request..& -
...- .
Description... 9
)..9 :
;..: ;
var00 
updatedCommercial00 !
=00" #
await00$ )

repository00* 4
.004 5
UpdateAsync005 @
(00@ A

commercial00A K
.00K L
Value00L Q
)00Q R
;00R S
if22 
(22 
!22 
updatedCommercial22 
.22 
	IsSuccess22 #
)22# $
{33 
return44 

new44 +
UpdateCommercialCommandResponse44 .
{55 
Success66 
=66 
false66 
,66 
ValidationErrors77 
=77 
new77 
List77  
<77  !
string77! '
>77' (
(77( )
)77) *
{77+ ,
updatedCommercial77- >
.77> ?
Error77? D
}77E F
}88 
;88 
}99 
return;; 	
new;;
 +
UpdateCommercialCommandResponse;; -
{<< 
Success== 
=== 
true== 
,== 

Commercial>> 
=>> 
new>> 
UpdateCommercialDto>> (
{?? 

BasePostId@@ 
=@@ 
updatedCommercial@@ #
.@@# $
Value@@$ )
.@@) *

BasePostId@@* 4
,@@4 5
UserIdAA 
=AA 
updatedCommercialAA 
.AA  
ValueAA  %
.AA% &
UserIdAA& ,
,AA, -
	TitlePostBB 
=BB 
updatedCommercialBB "
.BB" #
ValueBB# (
.BB( )
	TitlePostBB) 2
,BB2 3
PriceCC 

=CC 
updatedCommercialCC 
.CC 
ValueCC $
.CC$ %
PriceCC% *
,CC* +
	AddressIdDD 
=DD 
updatedCommercialDD "
.DD" #
ValueDD# (
.DD( )
	AddressIdDD) 2
,DD2 3
	OfferTypeEE 
=EE 
updatedCommercialEE "
.EE" #
ValueEE# (
.EE( )
	OfferTypeEE) 2
,EE2 3
DescriptionFF 
=FF 
updatedCommercialFF $
.FF$ %
ValueFF% *
.FF* +
DescriptionFF+ 6
,FF6 7
UsefulSurfaceGG 
=GG 
updatedCommercialGG &
.GG& '
ValueGG' ,
.GG, -
UsefulSurfaceGG- :
,GG: ;
DisponibilityHH 
=HH 
updatedCommercialHH &
.HH& '
ValueHH' ,
.HH, -
DisponibilityHH- :
,HH: ; 
CommercialSpecificIdII 
=II 
updatedCommercialII -
.II- .
ValueII. 3
.II3 4 
CommercialSpecificIdII4 H
}JJ 
}KK 
;KK 
}LL 
}MM 
}NN â
wD:\Real-Estate\RealEstate.Application\Features\Commercials\Commands\UpdateCommercial\UpdateCommercialCommandResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Commercials* 5
.5 6
Commands6 >
.> ?
UpdateCommercial? O
{ 
public 
class +
UpdateCommercialCommandResponse -
:- .
BaseResponse/ ;
{ 
public +
UpdateCommercialCommandResponse	 (
(( )
)) *
:* +
base, 0
(0 1
)1 2
{ 
}		 
public

 
UpdateCommercialDto

	 

Commercial

 '
{

( )
get

* -
;

- .
set

/ 2
;

2 3
}

4 5
} 
} Ä(
xD:\Real-Estate\RealEstate.Application\Features\Commercials\Commands\UpdateCommercial\UpdateCommercialCommandValidator.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Commercials* 5
.5 6
Commands6 >
.> ?
UpdateCommercial? O
{ 
public 
class ,
 UpdateCommercialCommandValidator .
:. /
AbstractValidator0 A
<A B#
UpdateCommercialCommandB Y
>Y Z
{ 
public ,
 UpdateCommercialCommandValidator	 )
() *
)* +
{ 
RuleFor		 
(		 
p		 
=>		 
p		 
.		 

BasePostId		 %
)		% &
.

 
NotEmpty

 
(

 
)

 
.

 
WithMessage

 '
(

' (
$str

( E
)

E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
UserId !
)! "
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
	TitlePost $
)$ %
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
Price  
)  !
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
. 
GreaterThan 
( 
$num 
) 
.  
WithMessage  +
(+ ,
$str, T
)T U
;U V
RuleFor 
( 
p 
=> 
p 
. 
	AddressId $
)$ %
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
	OfferType $
)$ %
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
.   
NotNull   
(   
)   
;   
RuleFor"" 
("" 
p"" 
=>"" 
p"" 
."" 
Description"" &
)""& '
.## 
NotEmpty## 
(## 
)## 
.## 
WithMessage## '
(##' (
$str##( E
)##E F
.$$ 
NotNull$$ 
($$ 
)$$ 
.%% 
MaximumLength%% 
(%% 
$num%% #
)%%# $
.%%$ %
WithMessage%%% 0
(%%0 1
$str%%1 b
)%%b c
;%%c d
RuleFor'' 
('' 
p'' 
=>'' 
p'' 
.'' 
UsefulSurface'' (
)''( )
.(( 
NotEmpty(( 
((( 
)(( 
.(( 
WithMessage(( 
((( 
$str(( 9
)((9 :
.)) 
NotNull)) 
()) 
))) 
.** 
GreaterThan** 
(** 
$num** 
)** 
.** 
WithMessage** 
(**  
$str**  H
)**H I
;**I J
RuleFor,, 

(,,
 
p,, 
=>,, 
p,, 
.,, 
Disponibility,, 
),,  
.-- 
NotEmpty-- 
(-- 
)-- 
.-- 
WithMessage-- 
(-- 
$str-- 9
)--9 :
... 
NotNull.. 
(.. 
).. 
;.. 
RuleFor00 

(00
 
p00 
=>00 
p00 
.00  
CommercialSpecificId00 &
)00& '
.11 
NotEmpty11 
(11 
)11 
.11 
WithMessage11 
(11 
$str11 9
)119 :
.22 
NotNull22 
(22 
)22 
.33 
NotEqual33 
(33 
Guid33 
.33 
Empty33 
)33 
;33 
}55 
}66 
}77 
kD:\Real-Estate\RealEstate.Application\Features\Commercials\Commands\UpdateCommercial\UpdateCommercialDto.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Commercials* 5
.5 6
Commands6 >
.> ?
UpdateCommercial? O
{ 
public 
class 
UpdateCommercialDto !
{ 
public 
Guid 

BasePostId 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
UserId 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
default- 4
!4 5
;5 6
public 
string 
	TitlePost 
{  !
get" %
;% &
set' *
;* +
}, -
=. /
default0 7
!7 8
;8 9
public 
double 
Price 
{ 
get !
;! "
set# &
;& '
}( )
public		 
Guid		 
	AddressId		 
{		 
get		  #
;		# $
set		% (
;		( )
}		* +
public

 
bool

 
	OfferType

 
{

 
get

  #
;

# $
set

% (
;

( )
}

* +
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
default2 9
!9 :
;: ;
public 
double 
? 
UsefulSurface $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
DateTime	 
? 
Disponibility  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
Guid	  
CommercialSpecificId "
{# $
get% (
;( )
set* -
;- .
}/ 0
} 
} –
SD:\Real-Estate\RealEstate.Application\Features\Commercials\Queries\CommercialDto.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Commercials* 5
.5 6
Queries6 =
{ 
public 

class 
CommercialDto 
{ 
public 
Guid 

BasePostId 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
UserId 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
default- 4
!4 5
;5 6
public 
string 
	TitlePost 
{  !
get" %
;% &
set' *
;* +
}, -
=. /
default0 7
!7 8
;8 9
public 
double 
Price 
{ 
get !
;! "
set# &
;& '
}( )
=* +
default, 3
!3 4
;4 5
public		 
Guid		 
	AddressId		 
{		 
get		  #
;		# $
set		% (
;		( )
}		* +
=		, -
default		. 5
!		5 6
;		6 7
public

 
bool

 
	OfferType

 
{

 
get

  #
;

# $
set

% (
;

( )
}

* +
=

, -
default

. 5
!

5 6
;

6 7
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
default2 9
!9 :
;: ;
public 
Guid  
CommercialSpecificId (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
double 
UsefulSurface #
{$ %
get& )
;) *
set+ .
;. /
}0 1
=2 3
default4 ;
!; <
;< =
public 
DateTime 
Disponibility %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
=4 5
default6 =
!= >
;> ?
} 
} ª
cD:\Real-Estate\RealEstate.Application\Features\Commercials\Queries\GetAll\GetAllCommercialsQuery.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Commercials* 5
.5 6
Queries6 =
.= >
GetAll> D
{ 
public 

class "
GetAllCommercialsQuery '
:( )
IRequest* 2
<2 3%
GetAllCommercialsResponse3 L
>L M
{ 
} 
} Ç
jD:\Real-Estate\RealEstate.Application\Features\Commercials\Queries\GetAll\GetAllCommercialsQueryHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Commercials* 5
.5 6
Queries6 =
.= >
GetAll> D
{ 
public 

class )
GetAllCommercialsQueryHandler .
:/ 0
IRequestHandler1 @
<@ A"
GetAllCommercialsQueryA W
,W X%
GetAllCommercialsResponseY r
>r s
{ 
private 
readonly !
ICommercialRepository .

repository/ 9
;9 :
public

 )
GetAllCommercialsQueryHandler

 ,
(

, -!
ICommercialRepository

- B

repository

C M
)

M N
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< %
GetAllCommercialsResponse 3
>3 4
Handle5 ;
(; <"
GetAllCommercialsQuery< R
requestS Z
,Z [
CancellationToken\ m
cancellationTokenn 
)	 Ä
{ 	%
GetAllCommercialsResponse %
response& .
=/ 0
new1 4
(4 5
)5 6
;6 7
var 
result 
= 
await 

repository )
.) *
GetAllAsync* 5
(5 6
)6 7
;7 8
if 
( 
result 
. 
	IsSuccess  
)  !
{ 
response 
. 
Commercials $
=% &
result' -
.- .
Value. 3
.3 4
Select4 :
(: ;

commercial; E
=>F H
newI L
CommercialDtoM Z
{ 

BasePostId 
=  

commercial! +
.+ ,

BasePostId, 6
,6 7
UserId 
= 

commercial '
.' (
UserId( .
,. /
	TitlePost 
= 

commercial  *
.* +
	TitlePost+ 4
,4 5
Price 
= 

commercial &
.& '
Price' ,
,, -
	AddressId 
= 

commercial  *
.* +
	AddressId+ 4
,4 5
	OfferType 
= 

commercial  *
.* +
	OfferType+ 4
,4 5
Description 
=  !

commercial" ,
., -
Description- 8
,8 9 
CommercialSpecificId (
=) *

commercial+ 5
.5 6 
CommercialSpecificId6 J
,J K
UsefulSurface   !
=  " #

commercial  $ .
.  . /
UsefulSurface  / <
,  < =
Disponibility!! !
=!!" #

commercial!!$ .
.!!. /
Disponibility!!/ <
}"" 
)"" 
."" 
ToList"" 
("" 
)"" 
;"" 
}## 
return$$ 
response$$ 
;$$ 
}%% 	
}&& 
}'' ≠
fD:\Real-Estate\RealEstate.Application\Features\Commercials\Queries\GetAll\GetAllCommercialsResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Commercials* 5
.5 6
Queries6 =
.= >
GetAll> D
{ 
public 

class %
GetAllCommercialsResponse *
{ 
public 
List 
< 
CommercialDto !
>! "
Commercials# .
{/ 0
get1 4
;4 5
set6 9
;9 :
}; <
} 
} „
dD:\Real-Estate\RealEstate.Application\Features\Commercials\Queries\GetById\GetByIdCommercialQuery.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Commercials* 5
.5 6
Queries6 =
.= >
GetById> E
{ 
public 

record "
GetByIdCommercialQuery (
(( )
Guid) -
Id. 0
)0 1
:2 3
IRequest4 <
<< =
CommercialDto= J
>J K
;K L
} é
kD:\Real-Estate\RealEstate.Application\Features\Commercials\Queries\GetById\GetByIdCommercialQueryHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Commercials* 5
.5 6
Queries6 =
.= >
GetById> E
{ 
public 

class )
GetByIdCommercialQueryHandler .
:/ 0
IRequestHandler1 @
<@ A"
GetByIdCommercialQueryA W
,W X
CommercialDtoY f
>f g
{ 
private 
readonly !
ICommercialRepository .

repository/ 9
;9 :
public

 )
GetByIdCommercialQueryHandler

 ,
(

, -!
ICommercialRepository

- B

repository

C M
)

M N
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< 
CommercialDto '
>' (
Handle) /
(/ 0"
GetByIdCommercialQuery0 F
requestG N
,N O
CancellationTokenP a
cancellationTokenb s
)s t
{ 	
var 

commercial 
= 
await "

repository# -
.- .
FindByIdAsync. ;
(; <
request< C
.C D
IdD F
)F G
;G H
if 
( 

commercial 
. 
	IsSuccess $
)$ %
{ 
return 
new 
CommercialDto (
{ 

BasePostId 
=  

commercial! +
.+ ,
Value, 1
.1 2

BasePostId2 <
,< =
UserId 
= 

commercial '
.' (
Value( -
.- .
UserId. 4
,4 5
	TitlePost 
= 

commercial  *
.* +
Value+ 0
.0 1
	TitlePost1 :
,: ;
Price 
= 

commercial &
.& '
Value' ,
., -
Price- 2
,2 3
	AddressId 
= 

commercial  *
.* +
Value+ 0
.0 1
	AddressId1 :
,: ;
	OfferType 
= 

commercial  *
.* +
Value+ 0
.0 1
	OfferType1 :
,: ;
Description 
=  !

commercial" ,
., -
Value- 2
.2 3
Description3 >
,> ? 
CommercialSpecificId (
=) *

commercial+ 5
.5 6
Value6 ;
.; < 
CommercialSpecificId< P
,P Q
UsefulSurface !
=" #

commercial$ .
.. /
Value/ 4
.4 5
UsefulSurface5 B
,B C
Disponibility   !
=  " #

commercial  $ .
.  . /
Value  / 4
.  4 5
Disponibility  5 B
}!! 
;!! 
}"" 
return## 
new## 
CommercialDto## $
(##$ %
)##% &
;##& '
}$$ 	
}%% 
}&& ©
uD:\Real-Estate\RealEstate.Application\Features\HotelPensions\Commands\CreateHotelPension\CreateHotelPensionCommand.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
HotelPensions* 7
.7 8
Commands8 @
.@ A
CreateHotelPensionA S
{ 
public 

class %
CreateHotelPensionCommand *
:+ ,
IRequest- 5
<5 6-
!CreateHotelPensionCommandResponse6 W
>W X
{ 
public 
string 
UserId 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
default- 4
!4 5
;5 6
public		 
string		 
	TitlePost		 
{		  !
get		" %
;		% &
set		' *
;		* +
}		, -
=		. /
default		0 7
!		7 8
;		8 9
public

 
double

 
Price

 
{

 
get

 !
;

! "
set

# &
;

& '
}

( )
=

* +
default

, 3
!

3 4
;

4 5
public 
Guid 
	AddressId 
{ 
get  #
;# $
set% (
;( )
}* +
=, -
default. 5
!5 6
;6 7
public 
bool 
	OfferType 
{ 
get  #
;# $
set% (
;( )
}* +
=, -
default. 5
!5 6
;6 7
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
default2 9
!9 :
;: ;
public 
double 
UsefulSurface #
{$ %
get& )
;) *
set+ .
;. /
}0 1
=2 3
default4 ;
;; <
public 
double 
RoomSurface !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
default2 9
!9 :
;: ;
public 
int 
	RoomCount 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
default- 4
!4 5
;5 6
} 
} è/
|D:\Real-Estate\RealEstate.Application\Features\HotelPensions\Commands\CreateHotelPension\CreateHotelPensionCommandHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
HotelPensions* 7
.7 8
Commands8 @
.@ A
CreateHotelPensionA S
{ 
public 

class ,
 CreateHotelPensionCommandHandler 1
:2 3
IRequestHandler4 C
<C D%
CreateHotelPensionCommandD ]
,] ^.
!CreateHotelPensionCommandResponse	_ Ä
>
Ä Å
{ 
private		 
readonly		 #
IHotelPensionRepository		 0

repository		1 ;
;		; <
public ,
 CreateHotelPensionCommandHandler /
(/ 0#
IHotelPensionRepository0 G

repositoryH R
)R S
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< -
!CreateHotelPensionCommandResponse ;
>; <
Handle= C
(C D%
CreateHotelPensionCommandD ]
request^ e
,e f
CancellationTokeng x
cancellationToken	y ä
)
ä ã
{ 	
var 
	validator 
= 
new .
"CreateHotelPensionCommandValidator  B
(B C
)C D
;D E
var 
validatorResult 
=  !
await" '
	validator( 1
.1 2
ValidateAsync2 ?
(? @
request@ G
,G H
cancellationTokenI Z
)Z [
;[ \
if 
( 
! 
validatorResult  
.  !
IsValid! (
)( )
{ 
return 
new -
!CreateHotelPensionCommandResponse <
{ 
Success 
= 
false #
,# $
ValidationErrors $
=% &
validatorResult' 6
.6 7
Errors7 =
.= >
Select> D
(D E
eE F
=>G I
eJ K
.K L
ErrorMessageL X
)X Y
.Y Z
ToListZ `
(` a
)a b
} 
; 
} 
var 
hotelPension 
= 
HotelPension +
.+ ,
Create, 2
(2 3
request3 :
.: ;
UserId; A
,A B
requestC J
.J K
	TitlePostK T
,T U
requestV ]
.] ^
Price^ c
,c d
requeste l
.l m
	AddressIdm v
,v w
requestx 
.	 Ä
	OfferType
Ä â
,
â ä
request
ä ë
.
ë í
Description
í ù
,
ù û
request
ü ¶
.
¶ ß
UsefulSurface
ß ¥
,
¥ µ
request
µ º
.
º Ω
RoomSurface
Ω »
,
» …
request
… –
.
– —
	RoomCount
— ⁄
)
⁄ €
;
€ ‹
if 
( 
! 
hotelPension 
. 
	IsSuccess '
)' (
{   
return!! 
new!! -
!CreateHotelPensionCommandResponse!! <
{"" 
Success## 
=## 
false## #
,### $
ValidationErrors$$ $
=$$% &
new$$' *
List$$+ /
<$$/ 0
string$$0 6
>$$6 7
($$7 8
)$$8 9
{$$: ;
hotelPension$$< H
.$$H I
Error$$I N
}$$O P
}%% 
;%% 
}&& 
await(( 

repository(( 
.(( 
AddAsync(( %
(((% &
hotelPension((& 2
.((2 3
Value((3 8
)((8 9
;((9 :
return** 
new** -
!CreateHotelPensionCommandResponse** 8
{++ 
Success,, 
=,, 
true,, 
,,, 
HotelPension-- 
=-- 
new-- "!
CreateHotelPensionDto--# 8
{.. 

BasePostId// 
=//  
hotelPension//! -
.//- .
Value//. 3
.//3 4

BasePostId//4 >
,//> ?
UserId00 
=00 
hotelPension00 )
.00) *
Value00* /
.00/ 0
UserId000 6
,006 7
	TitlePost11 
=11 
hotelPension11  ,
.11, -
Value11- 2
.112 3
	TitlePost113 <
,11< =
Price22 
=22 
hotelPension22 (
.22( )
Value22) .
.22. /
Price22/ 4
,224 5
	AddressId33 
=33 
hotelPension33  ,
.33, -
Value33- 2
.332 3
	AddressId333 <
,33< =
	OfferType44 
=44 
hotelPension44  ,
.44, -
Value44- 2
.442 3
	OfferType443 <
,44< =
Description55 
=55  !
hotelPension55" .
.55. /
Value55/ 4
.554 5
Description555 @
,55@ A
UsefulSurface66 !
=66" #
hotelPension66$ 0
.660 1
Value661 6
.666 7
UsefulSurface667 D
,66D E
RoomSurface77 
=77  !
hotelPension77" .
.77. /
Value77/ 4
.774 5
RoomSurface775 @
,77@ A
	RoomCount88 
=88 
hotelPension88  ,
.88, -
Value88- 2
.882 3
	RoomCount883 <
}99 
}:: 
;:: 
};; 	
}<< 
}== õ
}D:\Real-Estate\RealEstate.Application\Features\HotelPensions\Commands\CreateHotelPension\CreateHotelPensionCommandResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
HotelPensions* 7
.7 8
Commands8 @
.@ A
CreateHotelPensionA S
{ 
public 

class -
!CreateHotelPensionCommandResponse 2
:3 4
BaseResponse5 A
{ 
public -
!CreateHotelPensionCommandResponse 0
(0 1
)1 2
: 
base 
( 
) 
{		 	
}

 	
public !
CreateHotelPensionDto $
HotelPension% 1
{2 3
get4 7
;7 8
set9 <
;< =
}> ?
} 
} ·!
~D:\Real-Estate\RealEstate.Application\Features\HotelPensions\Commands\CreateHotelPension\CreateHotelPensionCommandValidator.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
HotelPensions* 7
.7 8
Commands8 @
.@ A
CreateHotelPensionA S
{ 
public 

class .
"CreateHotelPensionCommandValidator 3
:4 5
AbstractValidator6 G
<G H%
CreateHotelPensionCommandH a
>a b
{ 
public .
"CreateHotelPensionCommandValidator 1
(1 2
)2 3
{ 	
RuleFor		 
(		 
p		 
=>		 
p		 
.		 
UserId		 !
)		! "
.

 
NotEmpty

 
(

 
)

 
.

 
WithMessage

 '
(

' (
$str

( E
)

E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
	TitlePost $
)$ %
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
Price  
)  !
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
. 
GreaterThan 
( 
$num 
) 
.  
WithMessage  +
(+ ,
$str, T
)T U
;U V
RuleFor 
( 
p 
=> 
p 
. 
	AddressId $
)$ %
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
	OfferType $
)$ %
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
Description &
)& '
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
.   
NotNull   
(   
)   
.!! 
MaximumLength!! 
(!! 
$num!! #
)!!# $
.!!$ %
WithMessage!!% 0
(!!0 1
$str!!1 b
)!!b c
;!!c d
RuleFor## 
(## 
x## 
=>## 
x## 
.## 
UsefulSurface## (
)##( )
.$$ 
GreaterThan$$ 
($$ 
$num$$ 
)$$ 
.%% 
WithMessage%% 
(%% 
$str%% =
)%%= >
;%%> ?
RuleFor'' 
('' 
x'' 
=>'' 
x'' 
.'' 
RoomSurface'' &
)''& '
.(( 
GreaterThan(( 
((( 
$num(( 
)(( 
.)) 
WithMessage)) 
()) 
$str)) B
)))B C
;))C D
RuleFor++ 
(++ 
x++ 
=>++ 
x++ 
.++ 
	RoomCount++ $
)++$ %
.,, 
GreaterThan,, 
(,, 
$num,, 
),, 
.-- 
WithMessage-- 
(-- 
$str-- @
)--@ A
;--A B
}.. 	
}// 
}00 Œ
qD:\Real-Estate\RealEstate.Application\Features\HotelPensions\Commands\CreateHotelPension\CreateHotelPensionDto.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
HotelPensions* 7
.7 8
Commands8 @
.@ A
CreateHotelPensionA S
{ 
public 
class !
CreateHotelPensionDto #
{ 
public 
Guid 

BasePostId 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
UserId 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
default- 4
!4 5
;5 6
public 
string 
	TitlePost 
{  !
get" %
;% &
set' *
;* +
}, -
=. /
default0 7
!7 8
;8 9
public 
double 
Price 
{ 
get !
;! "
set# &
;& '
}( )
public		 
Guid		 
	AddressId		 
{		 
get		  #
;		# $
set		% (
;		( )
}		* +
public

 
bool

 
	OfferType

 
{

 
get

  #
;

# $
set

% (
;

( )
}

* +
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
default2 9
!9 :
;: ;
public 
double 
UsefulSurface #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
double 
RoomSurface !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
int 
	RoomCount 
{ 
get "
;" #
set$ '
;' (
}) *
} 
} Ó
nD:\Real-Estate\RealEstate.Application\Features\HotelPensions\Commands\DeleteHotelPension\DeleteHotelPension.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
HotelPensions* 7
.7 8
Commands8 @
.@ A
DeleteHotelPensionA S
{ 
public 

class 
DeleteHotelPension #
:$ %
IRequest& .
<. /&
DeleteHotelPensionResponse/ I
>I J
{ 
public 
Guid 

BasePostId 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
}		 Ã
uD:\Real-Estate\RealEstate.Application\Features\HotelPensions\Commands\DeleteHotelPension\DeleteHotelPensionHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
HotelPensions* 7
.7 8
Commands8 @
.@ A
DeleteHotelPensionA S
{ 
public 

class %
DeleteHotelPensionHandler *
:+ ,
IRequestHandler- <
<< =
DeleteHotelPension= O
,O P&
DeleteHotelPensionResponseQ k
>k l
{ 
private 
readonly #
IHotelPensionRepository 0

repository1 ;
;; <
public

 %
DeleteHotelPensionHandler

 (
(

( )#
IHotelPensionRepository

) @

repository

A K
)

K L
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< &
DeleteHotelPensionResponse 4
>4 5
Handle6 <
(< =
DeleteHotelPension= O
requestP W
,W X
CancellationTokenY j
cancellationTokenk |
)| }
{ 	
var 
result 
= 
await 

repository )
.) *
DeleteAsync* 5
(5 6
request6 =
.= >

BasePostId> H
)H I
;I J
if 
( 
! 
result 
. 
	IsSuccess  
)  !
{ 
return 
new &
DeleteHotelPensionResponse 5
{ 
Success 
= 
false #
,# $
ValidationErrors $
=% &
new' *
List+ /
</ 0
string0 6
>6 7
{8 9
result: @
.@ A
ErrorA F
}G H
} 
; 
} 
return 
new &
DeleteHotelPensionResponse 1
{ 
Success 
= 
true 
} 
; 
} 	
}   
}!! †
vD:\Real-Estate\RealEstate.Application\Features\HotelPensions\Commands\DeleteHotelPension\DeleteHotelPensionResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
HotelPensions* 7
.7 8
Commands8 @
.@ A
DeleteHotelPensionA S
{ 
public 

class &
DeleteHotelPensionResponse +
:, -
BaseResponse. :
{ 
} 
} ‘
uD:\Real-Estate\RealEstate.Application\Features\HotelPensions\Commands\UpdateHotelPension\UpdateHotelPensionCommand.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
HotelPensions* 7
.7 8
Commands8 @
.@ A
UpdateHotelPensionA S
{ 
public 
class %
UpdateHotelPensionCommand '
:' (
IRequest) 1
<1 2-
!UpdateHotelPensionCommandResponse2 S
>S T
{ 
public 
Guid	 

BasePostId 
{ 
get 
; 
set  #
;# $
}% &
public 
string	 
UserId 
{ 
get 
; 
set !
;! "
}# $
=% &
default' .
!. /
;/ 0
public		 
string			 
	TitlePost		 
{		 
get		 
;		  
set		! $
;		$ %
}		& '
=		( )
default		* 1
!		1 2
;		2 3
public

 
double

	 
Price

 
{

 
get

 
;

 
set

  
;

  !
}

" #
=

$ %
default

& -
!

- .
;

. /
public 
Guid	 
	AddressId 
{ 
get 
; 
set "
;" #
}$ %
=& '
default( /
!/ 0
;0 1
public 
bool	 
	OfferType 
{ 
get 
; 
set "
;" #
}$ %
=& '
default( /
!/ 0
;0 1
public 
string	 
Description 
{ 
get !
;! "
set# &
;& '
}( )
=* +
default, 3
!3 4
;4 5
public 
double	 
UsefulSurface 
{ 
get  #
;# $
set% (
;( )
}* +
=, -
default. 5
!5 6
;6 7
public 
double	 
RoomSurface 
{ 
get !
;! "
set# &
;& '
}( )
=* +
default, 3
!3 4
;4 5
public 
int	 
	RoomCount 
{ 
get 
; 
set !
;! "
}# $
=% &
default' .
!. /
;/ 0
} 
} ”=
|D:\Real-Estate\RealEstate.Application\Features\HotelPensions\Commands\UpdateHotelPension\UpdateHotelPensionCommandHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
HotelPensions* 7
.7 8
Commands8 @
.@ A
UpdateHotelPensionA S
{ 
public 
class ,
 UpdateHotelPensionCommandHandler .
:. /
IRequestHandler0 ?
<? @%
UpdateHotelPensionCommand@ Y
,Y Z-
!UpdateHotelPensionCommandResponse[ |
>| }
{ 
private 	
readonly
 #
IHotelPensionRepository *

repository+ 5
;5 6
public		 ,
 UpdateHotelPensionCommandHandler			 )
(		) *#
IHotelPensionRepository		* A

repository		B L
)		L M
{

 
this 
. 

repository 
= 

repository 
;  
} 
public 
async	 
Task 
< -
!UpdateHotelPensionCommandResponse 5
>5 6
Handle7 =
(= >%
UpdateHotelPensionCommand> W
requestX _
,_ `
CancellationTokena r
cancellationToken	s Ñ
)
Ñ Ö
{ 
var 
hotelPension 
= 
await 

repository &
.& '
FindByIdAsync' 4
(4 5
request5 <
.< =

BasePostId= G
)G H
;H I
var 
	validator 
= 
new .
"UpdateHotelPensionCommandValidator 9
(9 :
): ;
;; <
var 
validatorResult 
= 
await 
	validator (
.( )
ValidateAsync) 6
(6 7
request7 >
,> ?
cancellationToken@ Q
)Q R
;R S
if 
( 
! 
validatorResult 
. 
IsValid 
)  
{ 
return 

new -
!UpdateHotelPensionCommandResponse 0
{ 
Success 
= 
false 
, 
ValidationErrors 
= 
validatorResult '
.' (
Errors( .
.. /
Select/ 5
(5 6
e6 7
=>8 :
e; <
.< =
ErrorMessage= I
)I J
.J K
ToListK Q
(Q R
)R S
} 
; 
} 
if 
( 
! 
hotelPension 
. 
	IsSuccess 
) 
{ 
return 

new -
!UpdateHotelPensionCommandResponse 0
{   
Success!! 
=!! 
false!! 
,!! 
ValidationErrors"" 
="" 
new"" 
List""  
<""  !
string""! '
>""' (
(""( )
)"") *
{""+ ,
hotelPension""- 9
.""9 :
Error"": ?
}""@ A
}## 
;## 
}$$ 
hotelPension&& 
.&& 
Value&& 
.&& 
AttachRoomCount&& %
(&&% &
request&&& -
.&&- .
	RoomCount&&. 7
)&&7 8
;&&8 9
hotelPension'' 
.'' 
Value'' 
.'' 
AttachRoomSurface'' '
(''' (
request''( /
.''/ 0
RoomSurface''0 ;
)''; <
;''< =
hotelPension(( 
.(( 
Value(( 
.(( 
AttachUsefulSurface(( )
((() *
request((* 1
.((1 2
UsefulSurface((2 ?
)((? @
;((@ A
hotelPension)) 
.)) 
Value)) 
.)) 
AttachUserId)) "
())" #
request))# *
.))* +
UserId))+ 1
)))1 2
;))2 3
hotelPension** 
.** 
Value** 
.** 
AttachTitlePost** %
(**% &
request**& -
.**- .
	TitlePost**. 7
)**7 8
;**8 9
hotelPension++ 
.++ 
Value++ 
.++ 
AttachPrice++ !
(++! "
request++" )
.++) *
Price++* /
)++/ 0
;++0 1
hotelPension,, 
.,, 
Value,, 
.,, 
AttachAddressId,, %
(,,% &
request,,& -
.,,- .
	AddressId,,. 7
),,7 8
;,,8 9
hotelPension-- 
.-- 
Value-- 
.-- 
AttachOfferType-- %
(--% &
request--& -
.--- .
	OfferType--. 7
)--7 8
;--8 9
hotelPension.. 
... 
Value.. 
... 
AttachDescription.. '
(..' (
request..( /
.../ 0
Description..0 ;
)..; <
;..< =
var00 
updatedHotelPension00 
=00 
await00 "

repository00# -
.00- .
UpdateAsync00. 9
(009 :
hotelPension00: F
.00F G
Value00G L
)00L M
;00M N
if22 
(22 
!22 
updatedHotelPension22 
.22 
	IsSuccess22 %
)22% &
{33 
return44 

new44 -
!UpdateHotelPensionCommandResponse44 0
{55 
Success66 
=66 
false66 
,66 
ValidationErrors77 
=77 
new77 
List77  
<77  !
string77! '
>77' (
(77( )
)77) *
{77+ ,
updatedHotelPension77- @
.77@ A
Error77A F
}77G H
}88 
;88 
}99 
return;; 	
new;;
 -
!UpdateHotelPensionCommandResponse;; /
{<< 
Success== 
=== 
true== 
,== 
HotelPension>> 
=>> 
new>> !
UpdateHotelPensionDto>> ,
{?? 
UserId@@ 
=@@ 
updatedHotelPension@@ !
.@@! "
Value@@" '
.@@' (
UserId@@( .
,@@. /
	TitlePostAA 
=AA 
updatedHotelPensionAA $
.AA$ %
ValueAA% *
.AA* +
	TitlePostAA+ 4
,AA4 5
PriceBB 

=BB 
updatedHotelPensionBB  
.BB  !
ValueBB! &
.BB& '
PriceBB' ,
,BB, -
	AddressIdCC 
=CC 
updatedHotelPensionCC $
.CC$ %
ValueCC% *
.CC* +
	AddressIdCC+ 4
,CC4 5
	OfferTypeDD 
=DD 
updatedHotelPensionDD $
.DD$ %
ValueDD% *
.DD* +
	OfferTypeDD+ 4
,DD4 5
DescriptionEE 
=EE 
updatedHotelPensionEE &
.EE& '
ValueEE' ,
.EE, -
DescriptionEE- 8
,EE8 9
	RoomCountFF 
=FF 
updatedHotelPensionFF $
.FF$ %
ValueFF% *
.FF* +
	RoomCountFF+ 4
,FF4 5
RoomSurfaceGG 
=GG 
updatedHotelPensionGG &
.GG& '
ValueGG' ,
.GG, -
RoomSurfaceGG- 8
,GG8 9
UsefulSurfaceHH 
=HH 
updatedHotelPensionHH (
.HH( )
ValueHH) .
.HH. /
UsefulSurfaceHH/ <
}II 
}JJ 
;JJ 
}KK 
}LL 
}MM õ
}D:\Real-Estate\RealEstate.Application\Features\HotelPensions\Commands\UpdateHotelPension\UpdateHotelPensionCommandResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
HotelPensions* 7
.7 8
Commands8 @
.@ A
UpdateHotelPensionA S
{ 
public 
class -
!UpdateHotelPensionCommandResponse /
:/ 0
BaseResponse1 =
{ 
public -
!UpdateHotelPensionCommandResponse	 *
(* +
)+ ,
:, -
base. 2
(2 3
)3 4
{ 
}		 
public

 !
UpdateHotelPensionDto

	 
HotelPension

 +
{

, -
get

. 1
;

1 2
set

3 6
;

6 7
}

8 9
} 
} Ï)
~D:\Real-Estate\RealEstate.Application\Features\HotelPensions\Commands\UpdateHotelPension\UpdateHotelPensionCommandValidator.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
HotelPensions* 7
.7 8
Commands8 @
.@ A
UpdateHotelPensionA S
{ 
public 
class .
"UpdateHotelPensionCommandValidator 0
:0 1
AbstractValidator2 C
<C D%
UpdateHotelPensionCommandD ]
>] ^
{ 
public .
"UpdateHotelPensionCommandValidator	 +
(+ ,
), -
{ 
RuleFor		 
(		 
p		 
=>		 
p		 
.		 

BasePostId		 %
)		% &
.

 
NotEmpty

 
(

 
)

 
.

 
WithMessage

 '
(

' (
$str

( E
)

E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
UserId !
)! "
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
	TitlePost $
)$ %
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
Price  
)  !
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
. 
GreaterThan 
( 
$num 
) 
.  
WithMessage  +
(+ ,
$str, T
)T U
;U V
RuleFor 
( 
p 
=> 
p 
. 
	AddressId $
)$ %
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
	OfferType $
)$ %
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
.   
NotNull   
(   
)   
;   
RuleFor"" 
("" 
p"" 
=>"" 
p"" 
."" 
Description"" &
)""& '
.## 
NotEmpty## 
(## 
)## 
.## 
WithMessage## '
(##' (
$str##( E
)##E F
.$$ 
NotNull$$ 
($$ 
)$$ 
.%% 
MaximumLength%% 
(%% 
$num%% #
)%%# $
.%%$ %
WithMessage%%% 0
(%%0 1
$str%%1 b
)%%b c
;%%c d
RuleFor'' 
('' 
p'' 
=>'' 
p'' 
.'' 
UsefulSurface'' (
)''( )
.(( 
NotEmpty(( 
((( 
)(( 
.(( 
WithMessage(( 
((( 
$str(( 9
)((9 :
.)) 
NotNull)) 
()) 
))) 
.** 
GreaterThan** 
(** 
$num** 
)** 
.** 
WithMessage** 
(**  
$str**  H
)**H I
;**I J
RuleFor,, 

(,,
 
p,, 
=>,, 
p,, 
.,, 
RoomSurface,, 
),, 
.-- 
NotEmpty-- 
(-- 
)-- 
.-- 
WithMessage-- 
(-- 
$str-- 9
)--9 :
... 
NotNull.. 
(.. 
).. 
.// 
GreaterThan// 
(// 
$num// 
)// 
.// 
WithMessage// 
(//  
$str//  H
)//H I
;//I J
RuleFor11 

(11
 
p11 
=>11 
p11 
.11 
	RoomCount11 
)11 
.22 
NotNull22 
(22 
)22 
.22 
WithMessage22 
(22 
$str22 8
)228 9
.33 
NotEmpty33 
(33 
)33 
.44 
GreaterThan44 
(44 
$num44 
)44 
.44 
WithMessage44 
(44  
$str44  H
)44H I
;44I J
}55 
}66 
}77 ˚
qD:\Real-Estate\RealEstate.Application\Features\HotelPensions\Commands\UpdateHotelPension\UpdateHotelPensionDto.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
HotelPensions* 7
.7 8
Commands8 @
.@ A
UpdateHotelPensionA S
{ 
public 
class !
UpdateHotelPensionDto #
{ 
public 
Guid	 

BasePostId 
{ 
get 
; 
set  #
;# $
}% &
public 
string	 
UserId 
{ 
get 
; 
set !
;! "
}# $
=% &
default' .
!. /
;/ 0
public 
string	 
	TitlePost 
{ 
get 
;  
set! $
;$ %
}& '
=( )
default* 1
!1 2
;2 3
public 
double	 
Price 
{ 
get 
; 
set  
;  !
}" #
public		 
Guid			 
	AddressId		 
{		 
get		 
;		 
set		 "
;		" #
}		$ %
public

 
bool

	 
	OfferType

 
{

 
get

 
;

 
set

 "
;

" #
}

$ %
public 
string	 
Description 
{ 
get !
;! "
set# &
;& '
}( )
=* +
default, 3
!3 4
;4 5
public 
double	 
? 
UsefulSurface 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
double	 
? 
RoomSurface 
{ 
get "
;" #
set$ '
;' (
}) *
public 
int	 
? 
	RoomCount 
{ 
get 
; 
set "
;" #
}$ %
} 
} ≈
gD:\Real-Estate\RealEstate.Application\Features\HotelPensions\Queries\GetAll\GetAllHotelPensionsQuery.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
HotelPensions* 7
.7 8
Queries8 ?
.? @
GetAll@ F
{ 
public 

class $
GetAllHotelPensionsQuery )
:* +
IRequest, 4
<4 5'
GetAllHotelPensionsResponse5 P
>P Q
{ 
} 
} ú
nD:\Real-Estate\RealEstate.Application\Features\HotelPensions\Queries\GetAll\GetAllHotelPensionsQueryHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
HotelPensions* 7
.7 8
Queries8 ?
.? @
GetAll@ F
{ 
public 

class +
GetAllHotelPensionsQueryHandler 0
:1 2
IRequestHandler3 B
<B C$
GetAllHotelPensionsQueryC [
,[ \'
GetAllHotelPensionsResponse] x
>x y
{ 
private 
readonly #
IHotelPensionRepository 0

repository1 ;
;; <
public

 +
GetAllHotelPensionsQueryHandler

 .
(

. /#
IHotelPensionRepository

/ F

repository

G Q
)

Q R
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< '
GetAllHotelPensionsResponse 5
>5 6
Handle7 =
(= >$
GetAllHotelPensionsQuery> V
requestW ^
,^ _
CancellationToken` q
cancellationToken	r É
)
É Ñ
{ 	'
GetAllHotelPensionsResponse '
response( 0
=1 2
new3 6
(6 7
)7 8
;8 9
var 
result 
= 
await 

repository )
.) *
GetAllAsync* 5
(5 6
)6 7
;7 8
if 
( 
result 
. 
	IsSuccess  
)  !
{ 
response 
. 
HotelPensions &
=' (
result) /
./ 0
Value0 5
.5 6
Select6 <
(< =
hotelPension= I
=>J L
newM P
HotelPensionDtoQ `
{ 

BasePostId 
=  
hotelPension! -
.- .

BasePostId. 8
,8 9
UserId 
= 
hotelPension )
.) *
UserId* 0
,0 1
	TitlePost 
= 
hotelPension  ,
., -
	TitlePost- 6
,6 7
Price 
= 
hotelPension (
.( )
Price) .
,. /
	AddressId 
= 
hotelPension  ,
., -
	AddressId- 6
,6 7
	OfferType 
= 
hotelPension  ,
., -
	OfferType- 6
,6 7
Description 
=  !
hotelPension" .
.. /
Description/ :
,: ;
UsefulSurface !
=" #
hotelPension$ 0
.0 1
UsefulSurface1 >
,> ?
RoomSurface   
=    !
hotelPension  " .
.  . /
RoomSurface  / :
,  : ;
	RoomCount!! 
=!! 
hotelPension!!  ,
.!!, -
	RoomCount!!- 6
}"" 
)"" 
."" 
ToList"" 
("" 
)"" 
;"" 
}## 
return$$ 
response$$ 
;$$ 
}%% 	
}&& 
}'' π
jD:\Real-Estate\RealEstate.Application\Features\HotelPensions\Queries\GetAll\GetAllHotelPensionsResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
HotelPensions* 7
.7 8
Queries8 ?
.? @
GetAll@ F
{ 
public 

class '
GetAllHotelPensionsResponse ,
{ 
public 
List 
< 
HotelPensionDto #
># $
HotelPensions% 2
{3 4
get5 8
;8 9
set: =
;= >
}? @
} 
} Ì
hD:\Real-Estate\RealEstate.Application\Features\HotelPensions\Queries\GetById\GetByIdHotelPensionQuery.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
HotelPensions* 7
.7 8
Queries8 ?
.? @
GetById@ G
{ 
public 

record $
GetByIdHotelPensionQuery *
(* +
Guid+ /
Id0 2
)2 3
:4 5
IRequest6 >
<> ?
HotelPensionDto? N
>N O
;O P
} ¶
oD:\Real-Estate\RealEstate.Application\Features\HotelPensions\Queries\GetById\GetByIdHotelPensionQueryHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
HotelPensions* 7
.7 8
Queries8 ?
.? @
GetById@ G
{ 
public 

class +
GetByIdHotelPensionQueryHandler 0
:1 2
IRequestHandler3 B
<B C$
GetByIdHotelPensionQueryC [
,[ \
HotelPensionDto] l
>l m
{ 
private 
readonly #
IHotelPensionRepository 0

repository1 ;
;; <
public

 +
GetByIdHotelPensionQueryHandler

 .
(

. /#
IHotelPensionRepository

/ F

repository

G Q
)

Q R
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< 
HotelPensionDto )
>) *
Handle+ 1
(1 2$
GetByIdHotelPensionQuery2 J
requestK R
,R S
CancellationTokenT e
cancellationTokenf w
)w x
{ 	
var 
hotelPension 
= 
await $

repository% /
./ 0
FindByIdAsync0 =
(= >
request> E
.E F
IdF H
)H I
;I J
if 
( 
hotelPension 
. 
	IsSuccess &
)& '
{ 
return 
new 
HotelPensionDto *
{ 

BasePostId 
=  
hotelPension! -
.- .
Value. 3
.3 4

BasePostId4 >
,> ?
UserId 
= 
hotelPension )
.) *
Value* /
./ 0
UserId0 6
,6 7
	TitlePost 
= 
hotelPension  ,
., -
Value- 2
.2 3
	TitlePost3 <
,< =
Price 
= 
hotelPension (
.( )
Value) .
.. /
Price/ 4
,4 5
	AddressId 
= 
hotelPension  ,
., -
Value- 2
.2 3
	AddressId3 <
,< =
	OfferType 
= 
hotelPension  ,
., -
Value- 2
.2 3
	OfferType3 <
,< =
Description 
=  !
hotelPension" .
.. /
Value/ 4
.4 5
Description5 @
,@ A
UsefulSurface !
=" #
hotelPension$ 0
.0 1
Value1 6
.6 7
UsefulSurface7 D
,D E
RoomSurface 
=  !
hotelPension" .
.. /
Value/ 4
.4 5
RoomSurface5 @
,@ A
	RoomCount   
=   
hotelPension    ,
.  , -
Value  - 2
.  2 3
	RoomCount  3 <
}!! 
;!! 
}"" 
return## 
new## 
HotelPensionDto## &
(##& '
)##' (
;##( )
}$$ 	
}%% 
}&& »
WD:\Real-Estate\RealEstate.Application\Features\HotelPensions\Queries\HotelPensionDto.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
HotelPensions* 7
.7 8
Queries8 ?
{ 
public 
class 
HotelPensionDto 
{ 
public 
Guid 

BasePostId 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
UserId 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
default- 4
!4 5
;5 6
public 
string 
	TitlePost 
{  !
get" %
;% &
set' *
;* +
}, -
=. /
default0 7
!7 8
;8 9
public 
double 
Price 
{ 
get !
;! "
set# &
;& '
}( )
=* +
default, 3
!3 4
;4 5
public		 
Guid		 
	AddressId		 
{		 
get		  #
;		# $
set		% (
;		( )
}		* +
public

 
bool

 
	OfferType

 
{

 
get

  #
;

# $
set

% (
;

( )
}

* +
=

, -
default

. 5
!

5 6
;

6 7
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
default2 9
!9 :
;: ;
public 
double 
UsefulSurface #
{$ %
get& )
;) *
set+ .
;. /
}0 1
=2 3
default4 ;
!; <
;< =
public 
double 
RoomSurface !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
default2 9
!9 :
;: ;
public 
int 
	RoomCount 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
default- 4
!4 5
;5 6
} 
} õ
`D:\Real-Estate\RealEstate.Application\Features\Houses\Commands\CreateHouse\CreateHouseCommand.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Houses* 0
.0 1
Commands1 9
.9 :
CreateHouse: E
{ 
public 

class 
CreateHouseCommand #
:$ %
IRequest& .
<. /&
CreateHouseCommandResponse/ I
>I J
{ 
public 
string 
UserId 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
default- 4
!4 5
;5 6
public 
string 
	TitlePost 
{  !
get" %
;% &
set' *
;* +
}, -
=. /
default0 7
!7 8
;8 9
public		 
double		 
Price		 
{		 
get		 !
;		! "
set		# &
;		& '
}		( )
=		* +
default		, 3
!		3 4
;		4 5
public

 
Guid

 
	AddressId

 
{

 
get

  #
;

# $
set

% (
;

( )
}

* +
=

, -
default

. 5
!

5 6
;

6 7
public 
bool 
	OfferType 
{ 
get  #
;# $
set% (
;( )
}* +
=, -
default. 5
!5 6
;6 7
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
default2 9
!9 :
;: ;
public 
int 
	RoomCount 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
default- 4
!4 5
;5 6
public 
int 

FloorCount 
{ 
get  #
;# $
set% (
;( )
}* +
=, -
default. 5
!5 6
;6 7
public 
double 
UsefulSurface #
{$ %
get& )
;) *
set+ .
;. /
}0 1
=2 3
default4 ;
!; <
;< =
public 
double 
LotArea 
{ 
get  #
;# $
set% (
;( )
}* +
=, -
default. 5
!5 6
;6 7
public 
int 
	BuildYear 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
default- 4
!4 5
;5 6
public 
Guid 
HouseTypeId 
{  !
get" %
;% &
set' *
;* +
}, -
=. /
default0 7
!7 8
;8 9
} 
} é2
gD:\Real-Estate\RealEstate.Application\Features\Houses\Commands\CreateHouse\CreateHouseCommandHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Houses* 0
.0 1
Commands1 9
.9 :
CreateHouse: E
{ 
public 

class %
CreateHouseCommandHandler *
:+ ,
IRequestHandler- <
<< =
CreateHouseCommand= O
,O P&
CreateHouseCommandResponseQ k
>k l
{ 
private		 
readonly		 
IHouseRepository		 )

repository		* 4
;		4 5
public %
CreateHouseCommandHandler (
(( )
IHouseRepository) 9

repository: D
)D E
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< &
CreateHouseCommandResponse 4
>4 5
Handle6 <
(< =
CreateHouseCommand= O
requestP W
,W X
CancellationTokenY j
cancellationTokenk |
)| }
{ 	
var 
	validator 
= 
new '
CreateHouseCommandValidator  ;
(; <
)< =
;= >
var 
validationResult  
=! "
await# (
	validator) 2
.2 3
ValidateAsync3 @
(@ A
requestA H
,H I
cancellationTokenJ [
)[ \
;\ ]
if 
( 
! 
validationResult !
.! "
IsValid" )
)) *
{ 
return 
new &
CreateHouseCommandResponse 5
{ 
Success 
= 
false #
,# $
ValidationErrors $
=% &
validationResult' 7
.7 8
Errors8 >
.> ?
Select? E
(E F
eF G
=>H J
eK L
.L M
ErrorMessageM Y
)Y Z
.Z [
ToList[ a
(a b
)b c
} 
; 
} 
var 
house 
= 
House 
. 
Create $
($ %
request% ,
., -
UserId- 3
,3 4
request5 <
.< =
	TitlePost= F
,F G
requestH O
.O P
PriceP U
,U V
requestW ^
.^ _
	AddressId_ h
,h i
requestj q
.q r
	OfferTyper {
,{ |
request	} Ñ
.
Ñ Ö
Description
Ö ê
,
ê ë
request 
. 
	RoomCount !
,! "
request# *
.* +

FloorCount+ 5
,5 6
request7 >
.> ?
UsefulSurface? L
,L M
requestN U
.U V
LotAreaV ]
,] ^
request_ f
.f g
	BuildYearg p
,p q
requestr y
.y z
HouseTypeId	z Ö
)
Ö Ü
;
Ü á
if   
(   
!   
house   
.   
	IsSuccess    
)    !
{!! 
return"" 
new"" &
CreateHouseCommandResponse"" 5
{## 
Success$$ 
=$$ 
false$$ #
,$$# $
ValidationErrors%% $
=%%% &
new%%' *
List%%+ /
<%%/ 0
string%%0 6
>%%6 7
(%%7 8
)%%8 9
{%%: ;
house%%< A
.%%A B
Error%%B G
}%%H I
}&& 
;&& 
}'' 
await)) 

repository)) 
.)) 
AddAsync)) %
())% &
house))& +
.))+ ,
Value)), 1
)))1 2
;))2 3
return++ 
new++ &
CreateHouseCommandResponse++ 1
{,, 
Success-- 
=-- 
true-- 
,-- 
House.. 
=.. 
new.. 
CreateHouseDTO.. *
{// 

BasePostId00 
=00  
house00! &
.00& '
Value00' ,
.00, -

BasePostId00- 7
,007 8
UserId11 
=11 
house11 "
.11" #
Value11# (
.11( )
UserId11) /
,11/ 0
	TitlePost22 
=22 
house22  %
.22% &
Value22& +
.22+ ,
	TitlePost22, 5
,225 6
Price33 
=33 
house33 !
.33! "
Value33" '
.33' (
Price33( -
,33- .
	AddressId44 
=44 
house44  %
.44% &
Value44& +
.44+ ,
	AddressId44, 5
,445 6
	OfferType55 
=55 
house55  %
.55% &
Value55& +
.55+ ,
	OfferType55, 5
,555 6
Description66 
=66  !
house66" '
.66' (
Value66( -
.66- .
Description66. 9
,669 :
	RoomCount77 
=77 
house77  %
.77% &
Value77& +
.77+ ,
	RoomCount77, 5
,775 6

FloorCount88 
=88  
house88! &
.88& '
Value88' ,
.88, -

FloorCount88- 7
,887 8
UsefulSurface99 !
=99" #
house99$ )
.99) *
Value99* /
.99/ 0
UsefulSurface990 =
,99= >
LotArea:: 
=:: 
house:: #
.::# $
Value::$ )
.::) *
LotArea::* 1
,::1 2
	BuildYear;; 
=;; 
house;;  %
.;;% &
Value;;& +
.;;+ ,
	BuildYear;;, 5
,;;5 6
HouseTypeId<< 
=<<  !
house<<" '
.<<' (
Value<<( -
.<<- .
HouseTypeId<<. 9
}== 
}>> 
;>> 
}?? 	
}@@ 
}AA ‹
hD:\Real-Estate\RealEstate.Application\Features\Houses\Commands\CreateHouse\CreateHouseCommandResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Houses* 0
.0 1
Commands1 9
.9 :
CreateHouse: E
{ 
public 

class &
CreateHouseCommandResponse +
:, -
BaseResponse. :
{ 
public &
CreateHouseCommandResponse )
() *
)* +
:, -
base. 2
(2 3
)3 4
{ 	
}		 	
public 
CreateHouseDTO 
House #
{$ %
get& )
;) *
set+ .
;. /
}0 1
} 
} ¨2
iD:\Real-Estate\RealEstate.Application\Features\Houses\Commands\CreateHouse\CreateHouseCommandValidator.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Houses* 0
.0 1
Commands1 9
.9 :
CreateHouse: E
{ 
public 

class '
CreateHouseCommandValidator ,
:- .
AbstractValidator/ @
<@ A
CreateHouseCommandA S
>S T
{ 
public '
CreateHouseCommandValidator *
(* +
)+ ,
{ 	
RuleFor		 
(		 
p		 
=>		 
p		 
.		 
UserId		 !
)		! "
.

 
NotEmpty

 
(

 
)

 
.

 
WithMessage

 &
(

& '
$str

' D
)

D E
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
	TitlePost $
)$ %
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
Price  
)  !
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
. 
GreaterThan 
( 
$num 
) 
.  
WithMessage  +
(+ ,
$str, T
)T U
;U V
RuleFor 
( 
p 
=> 
p 
. 
	AddressId $
)$ %
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
	OfferType $
)$ %
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
Description &
)& '
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
.   
NotNull   
(   
)   
.!! 
MaximumLength!! 
(!! 
$num!! #
)!!# $
.!!$ %
WithMessage!!% 0
(!!0 1
$str!!1 b
)!!b c
;!!c d
RuleFor## 
(## 
p## 
=>## 
p## 
.## 
	RoomCount## $
)##$ %
.$$ 
NotEmpty$$ 
($$ 
)$$ 
.$$ 
WithMessage$$ '
($$' (
$str$$( E
)$$E F
.%% 
NotNull%% 
(%% 
)%% 
.&& 
GreaterThan&& 
(&& 
$num&& 
)&& 
.&&  
WithMessage&&  +
(&&+ ,
$str&&, T
)&&T U
;&&U V
RuleFor(( 
((( 
p(( 
=>(( 
p(( 
.(( 

FloorCount(( %
)((% &
.)) 
NotEmpty)) 
()) 
))) 
.)) 
WithMessage)) '
())' (
$str))( E
)))E F
.** 
NotNull** 
(** 
)** 
.++ 
GreaterThan++ 
(++ 
$num++ 
)++ 
.++  
WithMessage++  +
(+++ ,
$str++, T
)++T U
;++U V
RuleFor-- 
(-- 
p-- 
=>-- 
p-- 
.-- 
UsefulSurface-- (
)--( )
... 
NotEmpty.. 
(.. 
).. 
... 
WithMessage.. '
(..' (
$str..( E
)..E F
.// 
NotNull// 
(// 
)// 
.00 
GreaterThan00 
(00 
$num00 
)00 
.00  
WithMessage00  +
(00+ ,
$str00, T
)00T U
;00U V
RuleFor22 
(22 
p22 
=>22 
p22 
.22 
LotArea22 "
)22" #
.33 
NotEmpty33 
(33 
)33 
.33 
WithMessage33 '
(33' (
$str33( E
)33E F
.44 
NotNull44 
(44 
)44 
.55 
GreaterThan55 
(55 
$num55 
)55 
.55  
WithMessage55  +
(55+ ,
$str55, T
)55T U
;55U V
RuleFor77 
(77 
p77 
=>77 
p77 
.77 
	BuildYear77 $
)77$ %
.88 
NotEmpty88 
(88 
)88 
.88 
WithMessage88 '
(88' (
$str88( E
)88E F
.99 
NotNull99 
(99 
)99 
.:: 
InclusiveBetween:: !
(::! "
$num::" &
,::& '
DateTime::( 0
.::0 1
Now::1 4
.::4 5
Year::5 9
+::: ;
$num::< =
)::= >
;::> ?
RuleFor<< 
(<< 
p<< 
=><< 
p<< 
.<< 
HouseTypeId<< &
)<<& '
.== 
NotEmpty== 
(== 
)== 
.== 
WithMessage== '
(==' (
$str==( E
)==E F
.>> 
NotNull>> 
(>> 
)>> 
;>> 
}AA 	
}BB 
}CC Ω
\D:\Real-Estate\RealEstate.Application\Features\Houses\Commands\CreateHouse\CreateHouseDTO.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Houses* 0
.0 1
Commands1 9
.9 :
CreateHouse: E
{ 
public 

class 
CreateHouseDTO 
{ 
public 
Guid 

BasePostId 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
UserId 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
default- 4
!4 5
;5 6
public 
string 
	TitlePost 
{  !
get" %
;% &
set' *
;* +
}, -
=. /
default0 7
!7 8
;8 9
public 
double 
Price 
{ 
get !
;! "
set# &
;& '
}( )
public		 
Guid		 
	AddressId		 
{		 
get		  #
;		# $
set		% (
;		( )
}		* +
public

 
bool

 
	OfferType

 
{

 
get

  #
;

# $
set

% (
;

( )
}

* +
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
default2 9
!9 :
;: ;
public 
int 
? 
	RoomCount 
{ 
get  #
;# $
set% (
;( )
}* +
public 
int 
? 

FloorCount 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
double 
? 
UsefulSurface $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
double 
? 
LotArea 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
int 
? 
	BuildYear 
{ 
get  #
;# $
set% (
;( )
}* +
public 
Guid 
HouseTypeId 
{  !
get" %
;% &
set' *
;* +
}, -
} 
} Ω
YD:\Real-Estate\RealEstate.Application\Features\Houses\Commands\DeleteHouse\DeleteHouse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Houses* 0
.0 1
Commands1 9
.9 :
DeleteHouse: E
{ 
public 

class 
DeleteHouse 
: 
IRequest '
<' (
DeleteHouseResponse( ;
>; <
{ 
public 
Guid 

BasePostId 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
}		 „
`D:\Real-Estate\RealEstate.Application\Features\Houses\Commands\DeleteHouse\DeleteHouseHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Houses* 0
.0 1
Commands1 9
.9 :
DeleteHouse: E
{ 
public 

class 
DeleteHouseHandler #
:$ %
IRequestHandler& 5
<5 6
DeleteHouse6 A
,A B
DeleteHouseResponseC V
>V W
{ 
private 
readonly 
IHouseRepository )

repository* 4
;4 5
public

 
DeleteHouseHandler

 !
(

! "
IHouseRepository

" 2

repository

3 =
)

= >
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< 
DeleteHouseResponse -
>- .
Handle/ 5
(5 6
DeleteHouse6 A
requestB I
,I J
CancellationTokenK \
cancellationToken] n
)n o
{ 	
var 
result 
= 
await 

repository )
.) *
DeleteAsync* 5
(5 6
request6 =
.= >

BasePostId> H
)H I
;I J
if 
( 
! 
result 
. 
	IsSuccess  
)  !
{ 
return 
new 
DeleteHouseResponse .
{ 
Success 
= 
false #
,# $
ValidationErrors $
=% &
new' *
List+ /
</ 0
string0 6
>6 7
{8 9
result: @
.@ A
ErrorA F
}G H
} 
; 
} 
return 
new 
DeleteHouseResponse *
{ 
Success 
= 
true 
} 
; 
} 	
}   
}!! ˆ
aD:\Real-Estate\RealEstate.Application\Features\Houses\Commands\DeleteHouse\DeleteHouseResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Houses* 0
.0 1
Commands1 9
.9 :
DeleteHouse: E
{ 
public 

class 
DeleteHouseResponse $
:% &
BaseResponse' 3
{ 
} 
} œ
`D:\Real-Estate\RealEstate.Application\Features\Houses\Commands\UpdateHouse\UpdateHouseCommand.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Houses* 0
.0 1
Commands1 9
.9 :
UpdateHouse: E
{ 
public 
class 
UpdateHouseCommand  
:  !
IRequest" *
<* +&
UpdateHouseCommandResponse+ E
>E F
{ 
public 
Guid 

BasePostId 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
UserId 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
default- 4
!4 5
;5 6
public		 
string		 
	TitlePost		 
{		  !
get		" %
;		% &
set		' *
;		* +
}		, -
=		. /
default		0 7
!		7 8
;		8 9
public

 
double

 
Price

 
{

 
get

 !
;

! "
set

# &
;

& '
}

( )
=

* +
default

, 3
!

3 4
;

4 5
public 
Guid 
	AddressId 
{ 
get  #
;# $
set% (
;( )
}* +
=, -
default. 5
!5 6
;6 7
public 
bool 
	OfferType 
{ 
get  #
;# $
set% (
;( )
}* +
=, -
default. 5
!5 6
;6 7
public 
string	 
Description 
{ 
get !
;! "
set# &
;& '
}( )
=* +
default, 3
!3 4
;4 5
public 
int 
	RoomCount 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
default- 4
!4 5
;5 6
public 
Guid	 
HouseTypeId 
{ 
get 
;  
set! $
;$ %
}& '
public 
int	 
Comfort 
{ 
get 
; 
set 
;  
}! "
=# $
default% ,
!, -
;- .
public 
int	 

FloorCount 
{ 
get 
; 
set "
;" #
}$ %
=& '
default( /
!/ 0
;0 1
public 
double	 
UsefulSurface 
{ 
get  #
;# $
set% (
;( )
}* +
=, -
default. 5
!5 6
;6 7
public 
double	 
LotArea 
{ 
get 
; 
set "
;" #
}$ %
=& '
default( /
!/ 0
;0 1
public 
int	 
	BuildYear 
{ 
get 
; 
set !
;! "
}# $
=% &
default' .
!. /
;/ 0
} 
} ±G
gD:\Real-Estate\RealEstate.Application\Features\Houses\Commands\UpdateHouse\UpdateHouseCommandHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Houses* 0
.0 1
Commands1 9
.9 :
UpdateHouse: E
{ 
public 
class %
UpdateHouseCommandHandler '
:' (
IRequestHandler) 8
<8 9
UpdateHouseCommand9 K
,K L&
UpdateHouseCommandResponseM g
>g h
{ 
private 	
readonly
 
IHouseRepository #

repository$ .
;. /
public		 %
UpdateHouseCommandHandler			 "
(		" #
IHouseRepository		# 3

repository		4 >
)		> ?
{

 
this 
. 

repository 
= 

repository 
;  
} 
public 
async	 
Task 
< &
UpdateHouseCommandResponse .
>. /
Handle0 6
(6 7
UpdateHouseCommand7 I
requestJ Q
,Q R
CancellationTokenS d
cancellationTokene v
)v w
{ 
var 
house 
= 
await 

repository 
.  
FindByIdAsync  -
(- .
request. 5
.5 6

BasePostId6 @
)@ A
;A B
var 
	validator 
= 
new '
UpdateHouseCommandValidator 2
(2 3
)3 4
;4 5
var 
validatorResult 
= 
await 
	validator (
.( )
ValidateAsync) 6
(6 7
request7 >
,> ?
cancellationToken@ Q
)Q R
;R S
if 
( 
! 
validatorResult 
. 
IsValid 
)  
{ 
return 

new &
UpdateHouseCommandResponse )
{ 
Success 
= 
false 
, 
ValidationErrors 
= 
validatorResult '
.' (
Errors( .
.. /
Select/ 5
(5 6
e6 7
=>8 :
e; <
.< =
ErrorMessage= I
)I J
.J K
ToListK Q
(Q R
)R S
} 
; 
} 
if 
( 
! 
house 
. 
	IsSuccess 
) 
{ 
return 

new &
UpdateHouseCommandResponse )
{   
Success!! 
=!! 
false!! 
,!! 
ValidationErrors"" 
="" 
new"" 
List""  
<""  !
string""! '
>""' (
(""( )
)"") *
{""+ ,
house""- 2
.""2 3
Error""3 8
}""9 :
}## 
;## 
}$$ 
house&& 
.&& 	
Value&&	 
.&& 
AttachRoomCount&& 
(&& 
request&& &
.&&& '
	RoomCount&&' 0
)&&0 1
;&&1 2
house'' 
.'' 	
Value''	 
.'' 
AttachFloorCount'' 
(''  
request''  '
.''' (

FloorCount''( 2
)''2 3
;''3 4
house(( 
.(( 	
Value((	 
.(( 
AttachUsefulSurface(( "
(((" #
request((# *
.((* +
UsefulSurface((+ 8
)((8 9
;((9 :
house)) 
.)) 	
Value))	 
.)) 
AttachLotArea)) 
()) 
request)) $
.))$ %
LotArea))% ,
))), -
;))- .
house** 
.** 	
Value**	 
.** 
AttachBuildYear** 
(** 
request** &
.**& '
	BuildYear**' 0
)**0 1
;**1 2
house++ 
.++ 	
Value++	 
.++ 
AttachComfort++ 
(++ 
request++ $
.++$ %
Comfort++% ,
)++, -
;++- .
house,, 
.,, 	
Value,,	 
.,, 
AttachHouseTypeId,,  
(,,  !
request,,! (
.,,( )
HouseTypeId,,) 4
),,4 5
;,,5 6
house-- 
.-- 	
Value--	 
.-- 
AttachUserId-- 
(-- 
request-- #
.--# $
UserId--$ *
)--* +
;--+ ,
house.. 
... 	
Value..	 
... 
AttachTitlePost.. 
(.. 
request.. &
...& '
	TitlePost..' 0
)..0 1
;..1 2
house// 
.// 	
Value//	 
.// 
AttachPrice// 
(// 
request// "
.//" #
Price//# (
)//( )
;//) *
house00 
.00 	
Value00	 
.00 
AttachAddressId00 
(00 
request00 &
.00& '
	AddressId00' 0
)000 1
;001 2
house11 
.11 	
Value11	 
.11 
AttachOfferType11 
(11 
request11 &
.11& '
	OfferType11' 0
)110 1
;111 2
house22 
.22 	
Value22	 
.22 
AttachDescription22  
(22  !
request22! (
.22( )
Description22) 4
)224 5
;225 6
var44 
updatedHouse44 
=44 
await44 

repository44 &
.44& '
UpdateAsync44' 2
(442 3
house443 8
.448 9
Value449 >
)44> ?
;44? @
if66 
(66 
!66 
updatedHouse66 
.66 
	IsSuccess66 
)66 
{77 
return88 

new88 &
UpdateHouseCommandResponse88 )
{99 
Success:: 
=:: 
false:: 
,:: 
ValidationErrors;; 
=;; 
new;; 
List;;  
<;;  !
string;;! '
>;;' (
(;;( )
);;) *
{;;+ ,
updatedHouse;;- 9
.;;9 :
Error;;: ?
};;@ A
}<< 
;<< 
}== 
return?? 	
new??
 &
UpdateHouseCommandResponse?? (
{@@ 
SuccessAA 
=AA 
trueAA 
,AA 
HouseBB 	
=BB
 
newBB 
UpdateHouseDtoBB 
{CC 

BasePostIdDD 
=DD 
updatedHouseDD 
.DD 
ValueDD $
.DD$ %

BasePostIdDD% /
,DD/ 0
UserIdEE 
=EE 
updatedHouseEE 
.EE 
ValueEE  
.EE  !
UserIdEE! '
,EE' (
	TitlePostFF 
=FF 
updatedHouseFF 
.FF 
ValueFF #
.FF# $
	TitlePostFF$ -
,FF- .
PriceGG 

=GG 
updatedHouseGG 
.GG 
ValueGG 
.GG  
PriceGG  %
,GG% &
	AddressIdHH 
=HH 
updatedHouseHH 
.HH 
ValueHH #
.HH# $
	AddressIdHH$ -
,HH- .
	OfferTypeII 
=II 
updatedHouseII 
.II 
ValueII #
.II# $
	OfferTypeII$ -
,II- .
DescriptionJJ 
=JJ 
updatedHouseJJ 
.JJ  
ValueJJ  %
.JJ% &
DescriptionJJ& 1
,JJ1 2
	RoomCountKK 
=KK 
updatedHouseKK 
.KK 
ValueKK #
.KK# $
	RoomCountKK$ -
,KK- .

FloorCountLL 
=LL 
updatedHouseLL 
.LL 
ValueLL $
.LL$ %

FloorCountLL% /
,LL/ 0
UsefulSurfaceMM 
=MM 
updatedHouseMM !
.MM! "
ValueMM" '
.MM' (
UsefulSurfaceMM( 5
,MM5 6
LotAreaNN 
=NN 
updatedHouseNN 
.NN 
ValueNN !
.NN! "
LotAreaNN" )
,NN) *
	BuildYearOO 
=OO 
updatedHouseOO 
.OO 
ValueOO #
.OO# $
	BuildYearOO$ -
,OO- .
ComfortPP 
=PP 
updatedHousePP 
.PP 
ValuePP !
.PP! "
ComfortPP" )
,PP) *
HouseTypeIdQQ 
=QQ 
updatedHouseQQ 
.QQ  
ValueQQ  %
.QQ% &
HouseTypeIdQQ& 1
,QQ1 2
}RR 
}SS 
;SS 
}TT 
}UU 
}VV ‹
hD:\Real-Estate\RealEstate.Application\Features\Houses\Commands\UpdateHouse\UpdateHouseCommandResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Houses* 0
.0 1
Commands1 9
.9 :
UpdateHouse: E
{ 
public 
class &
UpdateHouseCommandResponse (
:( )
BaseResponse* 6
{ 
public &
UpdateHouseCommandResponse	 #
(# $
)$ %
:% &
base' +
(+ ,
), -
{ 
}		 
public

 
UpdateHouseDto

	 
House

 
{

 
get

  #
;

# $
set

% (
;

( )
}

* +
} 
} ‘8
iD:\Real-Estate\RealEstate.Application\Features\Houses\Commands\UpdateHouse\UpdateHouseCommandValidator.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Houses* 0
.0 1
Commands1 9
.9 :
UpdateHouse: E
{ 
public 
class '
UpdateHouseCommandValidator )
:) *
AbstractValidator+ <
<< =
UpdateHouseCommand= O
>O P
{ 
public '
UpdateHouseCommandValidator	 $
($ %
)% &
{ 
RuleFor		 
(		 
p		 
=>		 
p		 
.		 

BasePostId		 %
)		% &
.

 
NotEmpty

 
(

 
)

 
.

 
WithMessage

 '
(

' (
$str

( E
)

E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
UserId !
)! "
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
	TitlePost $
)$ %
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
Price  
)  !
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
. 
GreaterThan 
( 
$num 
) 
.  
WithMessage  +
(+ ,
$str, T
)T U
;U V
RuleFor 
( 
p 
=> 
p 
. 
	AddressId $
)$ %
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
	OfferType $
)$ %
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
.   
NotNull   
(   
)   
;   
RuleFor"" 

(""
 
p"" 
=>"" 
p"" 
."" 
Description"" 
)"" 
.## 
NotEmpty## 
(## 
)## 
.## 
WithMessage## 
(## 
$str## 9
)##9 :
.$$ 
NotNull$$ 
($$ 
)$$ 
.%% 
MaximumLength%% 
(%% 
$num%% 
)%% 
.%% 
WithMessage%% $
(%%$ %
$str%%% V
)%%V W
;%%W X
RuleFor'' 
('' 
p'' 
=>'' 
p'' 
.'' 
	RoomCount'' $
)''$ %
.(( 
NotEmpty(( 
((( 
)(( 
.(( 
WithMessage(( 
((( 
$str(( 9
)((9 :
.)) 
NotNull)) 
()) 
))) 
.** 
GreaterThan** 
(** 
$num** 
)** 
.** 
WithMessage** 
(**  
$str**  H
)**H I
;**I J
RuleFor,, 

(,,
 
p,, 
=>,, 
p,, 
.,, 

FloorCount,, 
),, 
.-- 
NotEmpty-- 
(-- 
)-- 
.-- 
WithMessage-- 
(-- 
$str-- 9
)--9 :
... 
NotNull.. 
(.. 
).. 
.// 
GreaterThan// 
(// 
$num// 
)// 
.// 
WithMessage// 
(//  
$str//  H
)//H I
;//I J
RuleFor11 

(11
 
p11 
=>11 
p11 
.11 
UsefulSurface11 
)11  
.22 
NotEmpty22 
(22 
)22 
.22 
WithMessage22 
(22 
$str22 9
)229 :
.33 
NotNull33 
(33 
)33 
.44 
GreaterThan44 
(44 
$num44 
)44 
.44 
WithMessage44 
(44  
$str44  H
)44H I
;44I J
RuleFor66 

(66
 
p66 
=>66 
p66 
.66 
LotArea66 
)66 
.77 
NotEmpty77 
(77 
)77 
.77 
WithMessage77 
(77 
$str77 9
)779 :
.88 
NotNull88 
(88 
)88 
.99 
GreaterThan99 
(99 
$num99 
)99 
.99 
WithMessage99 
(99  
$str99  H
)99H I
;99I J
RuleFor;; 

(;;
 
p;; 
=>;; 
p;; 
.;; 
	BuildYear;; 
);; 
.<< 
NotEmpty<< 
(<< 
)<< 
.<< 
WithMessage<< 
(<< 
$str<< 9
)<<9 :
.== 
NotNull== 
(== 
)== 
.>> 
GreaterThan>> 
(>> 
$num>> 
)>> 
.>> 
WithMessage>> "
(>>" #
$str>># K
)>>K L
;>>L M
RuleFor@@ 

(@@
 
p@@ 
=>@@ 
p@@ 
.@@ 
HouseTypeId@@ 
)@@ 
.AA 
NotEmptyAA 
(AA 
)AA 
.AA 
WithMessageAA 
(AA 
$strAA 9
)AA9 :
.BB 
NotNullBB 
(BB 
)BB 
.CC 
NotEqualCC 
(CC 
GuidCC 
.CC 
EmptyCC 
)CC 
;CC 
RuleForEE 

(EE
 
pEE 
=>EE 
pEE 
.EE 
ComfortEE 
)EE 
.FF 
NotEmptyFF 
(FF 
)FF 
.FF 
WithMessageFF 
(FF 
$strFF 9
)FF9 :
.GG 
NotNullGG 
(GG 
)GG 
;GG 
}II 
}JJ 
}KK ‰
\D:\Real-Estate\RealEstate.Application\Features\Houses\Commands\UpdateHouse\UpdateHouseDto.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Houses* 0
.0 1
Commands1 9
.9 :
UpdateHouse: E
{ 
public 
class 
UpdateHouseDto 
{ 
public 
Guid 

BasePostId 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
UserId 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
default- 4
!4 5
;5 6
public 
string 
	TitlePost 
{  !
get" %
;% &
set' *
;* +
}, -
=. /
default0 7
!7 8
;8 9
public 
double 
Price 
{ 
get !
;! "
set# &
;& '
}( )
public		 
Guid		 
	AddressId		 
{		 
get		  #
;		# $
set		% (
;		( )
}		* +
public

 
bool

 
	OfferType

 
{

 
get

  #
;

# $
set

% (
;

( )
}

* +
public 
string	 
Description 
{ 
get !
;! "
set# &
;& '
}( )
=* +
default, 3
!3 4
;4 5
public 
int 
? 
	RoomCount 
{ 
get  #
;# $
set% (
;( )
}* +
public 
Guid	 
HouseTypeId 
{ 
get 
;  
set! $
;$ %
}& '
public 
int	 
? 
Comfort 
{ 
get 
; 
set  
;  !
}" #
public 
int	 
? 

FloorCount 
{ 
get 
; 
set  #
;# $
}% &
public 
double	 
? 
UsefulSurface 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
double	 
? 
LotArea 
{ 
get 
; 
set  #
;# $
}% &
public 
int	 
? 
	BuildYear 
{ 
get 
; 
set "
;" #
}$ %
} 
} ¢
YD:\Real-Estate\RealEstate.Application\Features\Houses\Queries\GetAll\GetAllHousesQuery.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Houses* 0
.0 1
Queries1 8
.8 9
GetAll9 ?
{ 
public 

class 
GetAllHousesQuery "
:# $
IRequest% -
<- . 
GetAllHousesResponse. B
>B C
{ 
} 
} ≤
`D:\Real-Estate\RealEstate.Application\Features\Houses\Queries\GetAll\GetAllHousesQueryHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Houses* 0
.0 1
Queries1 8
.8 9
GetAll9 ?
{ 
public 

class $
GetAllHousesQueryHandler )
:* +
IRequestHandler, ;
<; <
GetAllHousesQuery< M
,M N 
GetAllHousesResponseO c
>c d
{ 
private 
readonly 
IHouseRepository )

repository* 4
;4 5
public

 $
GetAllHousesQueryHandler

 '
(

' (
IHouseRepository

( 8

repository

9 C
)

C D
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
<  
GetAllHousesResponse .
>. /
Handle0 6
(6 7
GetAllHousesQuery7 H
requestI P
,P Q
CancellationTokenR c
cancellationTokend u
)u v
{ 	 
GetAllHousesResponse  
response! )
=* +
new, /
(/ 0
)0 1
;1 2
var 
result 
= 
await 

repository )
.) *
GetAllAsync* 5
(5 6
)6 7
;7 8
if 
( 
result 
. 
	IsSuccess 
)  
{ 
response 
. 
Houses 
=  !
result" (
.( )
Value) .
.. /
Select/ 5
(5 6
house6 ;
=>< >
new? B
HouseDtoC K
{ 

BasePostId 
=  
house! &
.& '

BasePostId' 1
,1 2
UserId 
= 
house "
." #
UserId# )
,) *
	TitlePost 
= 
house  %
.% &
	TitlePost& /
,/ 0
Price 
= 
house !
.! "
Price" '
,' (
	AddressId 
= 
house  %
.% &
	AddressId& /
,/ 0
	OfferType 
= 
house  %
.% &
	OfferType& /
,/ 0
Description 
=  !
house" '
.' (
Description( 3
,3 4
	RoomCount 
= 
house  %
.% &
	RoomCount& /
,/ 0

FloorCount   
=    
house  ! &
.  & '

FloorCount  ' 1
,  1 2
UsefulSurface!! !
=!!" #
house!!$ )
.!!) *
UsefulSurface!!* 7
,!!7 8
LotArea"" 
="" 
house"" #
.""# $
LotArea""$ +
,""+ ,
	BuildYear## 
=## 
house##  %
.##% &
	BuildYear##& /
,##/ 0
HouseTypeId$$ 
=$$  !
house$$" '
.$$' (
HouseTypeId$$( 3
}%% 
)%% 
.%% 
ToList%% 
(%% 
)%% 
;%% 
}&& 
return'' 
response'' 
;'' 
}(( 	
})) 
}** è
\D:\Real-Estate\RealEstate.Application\Features\Houses\Queries\GetAll\GetAllHousesResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Houses* 0
.0 1
Queries1 8
.8 9
GetAll9 ?
{ 
public 

class  
GetAllHousesResponse %
{ 
public 
List 
< 
HouseDto 
> 
Houses $
{% &
get' *
;* +
set, /
;/ 0
}1 2
} 
}  
ZD:\Real-Estate\RealEstate.Application\Features\Houses\Queries\GetById\GetByIdHouseQuery.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Houses* 0
.0 1
Queries1 8
.8 9
GetById9 @
{ 
public 

record 
GetByIdHouseQuery #
(# $
Guid$ (
Id) +
)+ ,
:- .
IRequest/ 7
<7 8
HouseDto8 @
>@ A
;A B
} •
aD:\Real-Estate\RealEstate.Application\Features\Houses\Queries\GetById\GetByIdHouseQueryHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Houses* 0
.0 1
Queries1 8
.8 9
GetById9 @
{ 
public 

class $
GetByIdHouseQueryHandler )
:* +
IRequestHandler, ;
<; <
GetByIdHouseQuery< M
,M N
HouseDtoO W
>W X
{ 
private 
readonly 
IHouseRepository )

repository* 4
;4 5
public

 $
GetByIdHouseQueryHandler

 '
(

' (
IHouseRepository

( 8

repository

9 C
)

C D
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< 
HouseDto "
>" #
Handle$ *
(* +
GetByIdHouseQuery+ <
request= D
,D E
CancellationTokenF W
cancellationTokenX i
)i j
{ 	
var 
house 
= 
await 

repository (
.( )
FindByIdAsync) 6
(6 7
request7 >
.> ?
Id? A
)A B
;B C
if 
( 
house 
. 
	IsSuccess 
) 
{ 
return 
new 
HouseDto #
{ 

BasePostId 
=  
house! &
.& '
Value' ,
., -

BasePostId- 7
,7 8
UserId 
= 
house "
." #
Value# (
.( )
UserId) /
,/ 0
	TitlePost 
= 
house  %
.% &
Value& +
.+ ,
	TitlePost, 5
,5 6
Price 
= 
house !
.! "
Value" '
.' (
Price( -
,- .
	AddressId 
= 
house  %
.% &
Value& +
.+ ,
	AddressId, 5
,5 6
	OfferType 
= 
house  %
.% &
Value& +
.+ ,
	OfferType, 5
,5 6
Description 
=  !
house" '
.' (
Value( -
.- .
Description. 9
,9 :
	RoomCount 
= 
house  %
.% &
Value& +
.+ ,
	RoomCount, 5
,5 6

FloorCount 
=  
house! &
.& '
Value' ,
., -

FloorCount- 7
,7 8
UsefulSurface !
=" #
house$ )
.) *
Value* /
./ 0
UsefulSurface0 =
,= >
LotArea   
=   
house   #
.  # $
Value  $ )
.  ) *
LotArea  * 1
,  1 2
	BuildYear!! 
=!! 
house!!  %
.!!% &
Value!!& +
.!!+ ,
	BuildYear!!, 5
,!!5 6
HouseTypeId"" 
=""  !
house""" '
.""' (
Value""( -
.""- .
HouseTypeId"". 9
}## 
;## 
}$$ 
return%% 
new%% 
HouseDto%% 
(%%  
)%%  !
;%%! "
}&& 	
}'' 
}(( ¿
ID:\Real-Estate\RealEstate.Application\Features\Houses\Queries\HouseDto.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Houses* 0
.0 1
Queries1 8
{ 
public 

class 
HouseDto 
{ 
public 
Guid 

BasePostId 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
UserId 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
default- 4
!4 5
;5 6
public 
string 
	TitlePost 
{  !
get" %
;% &
set' *
;* +
}, -
=. /
default0 7
!7 8
;8 9
public 
double 
Price 
{ 
get !
;! "
set# &
;& '
}( )
=* +
default, 3
!3 4
;4 5
public		 
Guid		 
	AddressId		 
{		 
get		  #
;		# $
set		% (
;		( )
}		* +
=		, -
default		. 5
!		5 6
;		6 7
public

 
bool

 
	OfferType

 
{

 
get

  #
;

# $
set

% (
;

( )
}

* +
=

, -
default

. 5
!

5 6
;

6 7
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
default2 9
!9 :
;: ;
public 
int 
	RoomCount 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
default- 4
!4 5
;5 6
public 
int 

FloorCount 
{ 
get  #
;# $
set% (
;( )
}* +
=, -
default. 5
!5 6
;6 7
public 
double 
UsefulSurface #
{$ %
get& )
;) *
set+ .
;. /
}0 1
=2 3
default4 ;
!; <
;< =
public 
double 
LotArea 
{ 
get  #
;# $
set% (
;( )
}* +
=, -
default. 5
!5 6
;6 7
public 
int 
	BuildYear 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
default- 4
!4 5
;5 6
public 
Guid 
HouseTypeId 
{  !
get" %
;% &
set' *
;* +
}, -
} 
} ¨
lD:\Real-Estate\RealEstate.Application\Features\HouseTypes\Commands\CreateHouseType\CreateHouseTypeCommand.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

HouseTypes* 4
.4 5
Commands5 =
.= >
CreateHouseType> M
{ 
public 

class "
CreateHouseTypeCommand '
:( )
IRequest* 2
<2 3*
CreateHouseTypeCommandResponse3 Q
>Q R
{ 
public 
string 
Type 
{ 
get  
;  !
set" %
;% &
}' (
=) *
default+ 2
!2 3
;3 4
} 
}		 
sD:\Real-Estate\RealEstate.Application\Features\HouseTypes\Commands\CreateHouseType\CreateHouseTypeCommandHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

HouseTypes* 4
.4 5
Commands5 =
.= >
CreateHouseType> M
{ 
public 

class )
CreateHouseTypeCommandHandler .
:/ 0
IRequestHandler1 @
<@ A"
CreateHouseTypeCommandA W
,W X*
CreateHouseTypeCommandResponseY w
>w x
{ 
private		 
readonly		  
IHouseTypeRepository		 -

repository		. 8
;		8 9
public

 )
CreateHouseTypeCommandHandler

 ,
(

, - 
IHouseTypeRepository

- A

repository

B L
)

L M
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< *
CreateHouseTypeCommandResponse 8
>8 9
Handle: @
(@ A"
CreateHouseTypeCommandA W
requestX _
,_ `
CancellationTokena r
cancellationToken	s Ñ
)
Ñ Ö
{ 	
var 
	validator 
= 
new +
CreateHouseTypeCommandValidator  ?
(? @
)@ A
;A B
var 
validationResult  
=! "
await# (
	validator) 2
.2 3
ValidateAsync3 @
(@ A
requestA H
,H I
cancellationTokenJ [
)[ \
;\ ]
if 
( 
! 
validationResult !
.! "
IsValid" )
)) *
{ 
return 
new *
CreateHouseTypeCommandResponse 9
{ 
Success 
= 
false #
,# $
ValidationErrors $
=% &
validationResult' 7
.7 8
Errors8 >
.> ?
Select? E
(E F
eF G
=>H J
eK L
.L M
ErrorMessageM Y
)Y Z
.Z [
ToList[ a
(a b
)b c
} 
; 
} 
var 
	houseType 
= 
	HouseType %
.% &
Create& ,
(, -
request- 4
.4 5
Type5 9
)9 :
;: ;
if 
( 
! 
	houseType 
. 
	IsSuccess $
)$ %
{ 
return   
new   *
CreateHouseTypeCommandResponse   9
{!! 
Success"" 
="" 
false"" #
,""# $
ValidationErrors## $
=##% &
new##' *
List##+ /
<##/ 0
string##0 6
>##6 7
(##7 8
)##8 9
{##: ;
	houseType##< E
.##E F
Error##F K
}##L M
}$$ 
;$$ 
}%% 
await'' 

repository'' 
.'' 
AddAsync'' %
(''% &
	houseType''& /
.''/ 0
Value''0 5
)''5 6
;''6 7
return)) 
new)) *
CreateHouseTypeCommandResponse)) 5
{** 
Success++ 
=++ 
true++ 
,++ 
	HouseType,, 
=,, 
new,, 
CreateHouseTypeDTO,,  2
{-- 
Id.. 
=.. 
	houseType.. "
..." #
Value..# (
...( )
Id..) +
,..+ ,
Type// 
=// 
	houseType// $
.//$ %
Value//% *
.//* +
Type//+ /
}00 
}11 
;11 
}22 	
}33 
}44 Ä
tD:\Real-Estate\RealEstate.Application\Features\HouseTypes\Commands\CreateHouseType\CreateHouseTypeCommandResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

HouseTypes* 4
.4 5
Commands5 =
.= >
CreateHouseType> M
{ 
public 

class *
CreateHouseTypeCommandResponse /
:0 1
BaseResponse2 >
{ 
public *
CreateHouseTypeCommandResponse -
(- .
). /
:0 1
base2 6
(6 7
)7 8
{ 	
}		 	
public 
CreateHouseTypeDTO !
	HouseType" +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
} 
} –
uD:\Real-Estate\RealEstate.Application\Features\HouseTypes\Commands\CreateHouseType\CreateHouseTypeCommandValidator.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

HouseTypes* 4
.4 5
Commands5 =
.= >
CreateHouseType> M
{ 
public 

class +
CreateHouseTypeCommandValidator 0
:1 2
AbstractValidator3 D
<D E"
CreateHouseTypeCommandE [
>[ \
{ 
public +
CreateHouseTypeCommandValidator .
(. /
)/ 0
{ 	
RuleFor		 
(		 
p		 
=>		 
p		 
.		 
Type		 
)		  
.

 
NotEmpty

 
(

 
)

 
.

 
WithMessage

 '
(

' (
$str

( E
)

E F
. 
NotNull 
( 
) 
; 
} 	
} 
} ñ
hD:\Real-Estate\RealEstate.Application\Features\HouseTypes\Commands\CreateHouseType\CreateHouseTypeDTO.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

HouseTypes* 4
.4 5
Commands5 =
.= >
CreateHouseType> M
{ 
public 

class 
CreateHouseTypeDTO #
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
string 
? 
Type 
{ 
get !
;! "
set# &
;& '
}( )
} 
} —
eD:\Real-Estate\RealEstate.Application\Features\HouseTypes\Commands\DeleteHouseType\DeleteHouseType.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

HouseTypes* 4
.4 5
Commands5 =
.= >
DeleteHouseType> M
{ 
public 

class 
DeleteHouseType  
:! "
IRequest# +
<+ ,#
DeleteHouseTypeResponse, C
>C D
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
} 
}		 ó
lD:\Real-Estate\RealEstate.Application\Features\HouseTypes\Commands\DeleteHouseType\DeleteHouseTypeHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

HouseTypes* 4
.4 5
Commands5 =
.= >
DeleteHouseType> M
{ 
public 

class "
DeleteHouseTypeHandler '
:( )
IRequestHandler* 9
<9 :
DeleteHouseType: I
,I J#
DeleteHouseTypeResponseK b
>b c
{ 
private 
readonly  
IHouseTypeRepository -

repository. 8
;8 9
public

 "
DeleteHouseTypeHandler

 %
(

% & 
IHouseTypeRepository

& :

repository

; E
)

E F
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< #
DeleteHouseTypeResponse 1
>1 2
Handle3 9
(9 :
DeleteHouseType: I
requestJ Q
,Q R
CancellationTokenS d
cancellationTokene v
)v w
{ 	
var 
result 
= 
await 

repository )
.) *
DeleteAsync* 5
(5 6
request6 =
.= >
Id> @
)@ A
;A B
if 
( 
! 
result 
. 
	IsSuccess !
)! "
{ 
return 
new #
DeleteHouseTypeResponse 2
{ 
Success 
= 
false #
,# $
ValidationErrors $
=% &
new' *
List+ /
</ 0
string0 6
>6 7
{8 9
result: @
.@ A
ErrorA F
}G H
} 
; 
} 
return 
new #
DeleteHouseTypeResponse .
{ 
Success 
= 
true 
} 
; 
} 	
}   
}!! é
mD:\Real-Estate\RealEstate.Application\Features\HouseTypes\Commands\DeleteHouseType\DeleteHouseTypeResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

HouseTypes* 4
.4 5
Commands5 =
.= >
DeleteHouseType> M
{ 
public 

class #
DeleteHouseTypeResponse (
:) *
BaseResponse+ 7
{ 
} 
} ¿
lD:\Real-Estate\RealEstate.Application\Features\HouseTypes\Commands\UpdateHouseType\UpdateHouseTypeCommand.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

HouseTypes* 4
.4 5
Commands5 =
.= >
UpdateHouseType> M
{ 
public 
class "
UpdateHouseTypeCommand $
:$ %
IRequest& .
<. /*
UpdateHouseTypeCommandResponse/ M
>M N
{ 
public 
Guid	 
Id 
{ 
get 
; 
set 
; 
} 
public 
string	 
Type 
{ 
get 
; 
set 
;  
}! "
=# $
default% ,
!, -
;- .
}		 
} È%
sD:\Real-Estate\RealEstate.Application\Features\HouseTypes\Commands\UpdateHouseType\UpdateHouseTypeCommandHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

HouseTypes* 4
.4 5
Commands5 =
.= >
UpdateHouseType> M
{ 
public 
class )
UpdateHouseTypeCommandHandler +
:+ ,
IRequestHandler- <
<< ="
UpdateHouseTypeCommand= S
,S T*
UpdateHouseTypeCommandResponseU s
>s t
{ 
private 	
readonly
  
IHouseTypeRepository '

repository( 2
;2 3
public		 )
UpdateHouseTypeCommandHandler			 &
(		& ' 
IHouseTypeRepository		' ;

repository		< F
)		F G
{

 
this 
. 

repository 
= 

repository 
;  
} 
public 
async	 
Task 
< *
UpdateHouseTypeCommandResponse 2
>2 3
Handle4 :
(: ;"
UpdateHouseTypeCommand; Q
requestR Y
,Y Z
CancellationToken[ l
cancellationTokenm ~
)~ 
{ 
var 
	houseType 
= 
await 

repository #
.# $
FindByIdAsync$ 1
(1 2
request2 9
.9 :
Id: <
)< =
;= >
var 
	validator 
= 
new +
UpdateHouseTypeCommandValidator 6
(6 7
)7 8
;8 9
var 
validatorResult 
= 
await 
	validator (
.( )
ValidateAsync) 6
(6 7
request7 >
,> ?
cancellationToken@ Q
)Q R
;R S
if 
( 
! 
validatorResult 
. 
IsValid 
)  
{ 
return 

new *
UpdateHouseTypeCommandResponse -
{ 
Success 
= 
false 
, 
ValidationErrors 
= 
validatorResult '
.' (
Errors( .
.. /
Select/ 5
(5 6
e6 7
=>8 :
e; <
.< =
ErrorMessage= I
)I J
.J K
ToListK Q
(Q R
)R S
} 
; 
} 
if 
( 
! 
	houseType 
. 
	IsSuccess 
) 
{ 
return 

new *
UpdateHouseTypeCommandResponse -
{   
Success!! 
=!! 
false!! 
,!! 
ValidationErrors"" 
="" 
new"" 
List""  
<""  !
string""! '
>""' (
(""( )
)"") *
{""+ ,
	houseType""- 6
.""6 7
Error""7 <
}""= >
}## 
;## 
}$$ 
	houseType&& 
.&& 
Value&& 
.&& 

AttachType&& 
(&& 
request&& %
.&&% &
Type&&& *
)&&* +
;&&+ ,
var'' 
updatedHouseType'' 
='' 
await'' 

repository''  *
.''* +
UpdateAsync''+ 6
(''6 7
	houseType''7 @
.''@ A
Value''A F
)''F G
;''G H
if)) 
()) 
!)) 
updatedHouseType)) 
.)) 
	IsSuccess)) "
)))" #
{** 
return++ 

new++ *
UpdateHouseTypeCommandResponse++ -
{,, 
Success-- 
=-- 
false-- 
,-- 
ValidationErrors.. 
=.. 
new.. 
List..  
<..  !
string..! '
>..' (
(..( )
)..) *
{..+ ,
updatedHouseType..- =
...= >
Error..> C
}..D E
}// 
;// 
}00 
return22 	
new22
 *
UpdateHouseTypeCommandResponse22 ,
{33 
Success44 
=44 
true44 
,44 
	HouseType55 
=55 
new55 
UpdateHouseTypeDto55 &
{66 
Type77 	
=77
 
updatedHouseType77 
.77 
Value77 "
.77" #
Type77# '
}88 
}99 
;99 
}:: 
};; 
}<< Ä
tD:\Real-Estate\RealEstate.Application\Features\HouseTypes\Commands\UpdateHouseType\UpdateHouseTypeCommandResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

HouseTypes* 4
.4 5
Commands5 =
.= >
UpdateHouseType> M
{ 
public 
class *
UpdateHouseTypeCommandResponse ,
:, -
BaseResponse. :
{ 
public *
UpdateHouseTypeCommandResponse	 '
(' (
)( )
:) *
base+ /
(/ 0
)0 1
{ 
}		 
public

 
UpdateHouseTypeDto

	 
	HouseType

 %
{

& '
get

( +
;

+ ,
set

- 0
;

0 1
}

2 3
} 
} Â
uD:\Real-Estate\RealEstate.Application\Features\HouseTypes\Commands\UpdateHouseType\UpdateHouseTypeCommandValidator.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

HouseTypes* 4
.4 5
Commands5 =
.= >
UpdateHouseType> M
{ 
public 
class +
UpdateHouseTypeCommandValidator -
:- .
AbstractValidator/ @
<@ A"
UpdateHouseTypeCommandA W
>W X
{ 
public +
UpdateHouseTypeCommandValidator	 (
(( )
)) *
{ 
RuleFor		 

(		
 
x		 
=>		 
x		 
.		 
Id		 
)		 
.

 
NotEmpty

 
(

 
)

 
.

 
WithMessage

 
(

 
$str

 9
)

9 :
. 
NotNull 
( 
) 
. 
NotEqual 
( 
Guid 
. 
Empty 
) 
; 
RuleFor 

(
 
x 
=> 
x 
. 
Type 
) 
. 
NotEmpty 
( 
) 
. 
WithMessage 
( 
$str 9
)9 :
. 
NotNull 
( 
) 
. 
MaximumLength 
( 
$num 
) 
. 
WithMessage "
(" #
$str# R
)R S
;S T
} 
} 
} Ç
hD:\Real-Estate\RealEstate.Application\Features\HouseTypes\Commands\UpdateHouseType\UpdateHouseTypeDto.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

HouseTypes* 4
.4 5
Commands5 =
.= >
UpdateHouseType> M
{ 
public 
class 
UpdateHouseTypeDto  
{ 
public 
string	 
? 
Type 
{ 
get 
; 
set  
;  !
}" #
} 
} ∂
aD:\Real-Estate\RealEstate.Application\Features\HouseTypes\Queries\GetAll\GetAllHouseTypesQuery.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

HouseTypes* 4
.4 5
Queries5 <
.< =
GetAll= C
{ 
public 

class !
GetAllHouseTypesQuery &
:' (
IRequest) 1
<1 2$
GetAllHouseTypesResponse2 J
>J K
{ 
} 
} ¢
hD:\Real-Estate\RealEstate.Application\Features\HouseTypes\Queries\GetAll\GetAllHouseTypesQueryHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

HouseTypes* 4
.4 5
Queries5 <
.< =
GetAll= C
{ 
public 
class (
GetAllHouseTypesQueryHandler *
:+ ,
IRequestHandler- <
<< =!
GetAllHouseTypesQuery= R
,R S$
GetAllHouseTypesResponseT l
>l m
{ 
private 
readonly  
IHouseTypeRepository -

repository. 8
;8 9
public		 (
GetAllHouseTypesQueryHandler		 +
(		+ , 
IHouseTypeRepository		, @

repository		A K
)		K L
{

 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< $
GetAllHouseTypesResponse 2
>2 3
Handle4 :
(: ;!
GetAllHouseTypesQuery; P
requestQ X
,X Y
CancellationTokenZ k
cancellationTokenl }
)} ~
{ 	$
GetAllHouseTypesResponse $
response% -
=. /
new0 3
(3 4
)4 5
;5 6
var 
result 
= 
await 

repository )
.) *
GetAllAsync* 5
(5 6
)6 7
;7 8
if 
( 
result 
. 
	IsSuccess 
)  
{ 
response 
. 

HouseTypes #
=$ %
result& ,
., -
Value- 2
.2 3
Select3 9
(9 :
	houseType: C
=>D F
newG J
HouseTypeDtoK W
{ 
Id 
= 
	houseType "
." #
Id# %
,% &
Type 
= 
	houseType $
.$ %
Type% )
} 
) 
. 
ToList 
( 
) 
; 
} 
return 
response 
; 
} 	
} 
} ß
dD:\Real-Estate\RealEstate.Application\Features\HouseTypes\Queries\GetAll\GetAllHouseTypesResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

HouseTypes* 4
.4 5
Queries5 <
.< =
GetAll= C
{ 
public 

class $
GetAllHouseTypesResponse )
{ 
public 
List 
< 
HouseTypeDto  
>  !

HouseTypes" ,
{- .
get/ 2
;2 3
set4 7
;7 8
}9 :
} 
} ﬁ
bD:\Real-Estate\RealEstate.Application\Features\HouseTypes\Queries\GetById\GetByIdHouseTypeQuery.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

HouseTypes* 4
.4 5
Queries5 <
.< =
GetById= D
{ 
public 

record !
GetByIdHouseTypeQuery '
(' (
Guid( ,
Id- /
)/ 0
:1 2
IRequest3 ;
<; <
HouseTypeDto< H
>H I
;I J
} ü
iD:\Real-Estate\RealEstate.Application\Features\HouseTypes\Queries\GetById\GetByIdHouseTypeQueryHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

HouseTypes* 4
.4 5
Queries5 <
.< =
GetById= D
{ 
public 

class (
GetByIdHouseTypeQueryHandler -
:. /
IRequestHandler0 ?
<? @!
GetByIdHouseTypeQuery@ U
,U V
HouseTypeDtoW c
>c d
{ 
private 
readonly  
IHouseTypeRepository -

repository. 8
;8 9
public		 (
GetByIdHouseTypeQueryHandler		 +
(		+ , 
IHouseTypeRepository		, @

repository		A K
)		K L
{

 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< 
HouseTypeDto &
>& '
Handle( .
(. /!
GetByIdHouseTypeQuery/ D
requestE L
,L M
CancellationTokenN _
cancellationToken` q
)q r
{ 	
var 
	houseType 
= 
await !

repository" ,
., -
FindByIdAsync- :
(: ;
request; B
.B C
IdC E
)E F
;F G
if 
( 
	houseType 
. 
	IsSuccess "
)" #
{ 
return 
new 
HouseTypeDto '
{ 
Id 
= 
	houseType "
." #
Value# (
.( )
Id) +
,+ ,
Type 
= 
	houseType $
.$ %
Value% *
.* +
Type+ /
} 
; 
} 
return 
new 
HouseTypeDto #
(# $
)$ %
;% &
} 	
} 
} ˇ
QD:\Real-Estate\RealEstate.Application\Features\HouseTypes\Queries\HouseTypeDto.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *

HouseTypes* 4
.4 5
Queries5 <
{ 
public 
class 
HouseTypeDto 
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
string 
Type 
{ 
get  
;  !
set" %
;% &
}' (
=) *
default+ 2
!2 3
;3 4
} 
} ¬
ÖD:\Real-Estate\RealEstate.Application\Features\LotClassifications\Commands\CreateLotClassifications\CreateLotClassificationCommand.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
LotClassifications* <
.< =$
CreateLotClassifications= U
{ 
public 

class *
CreateLotClassificationCommand /
:0 1
IRequest2 :
<: ;2
&CreateLotClassificationCommandResponse; a
>a b
{ 
public 
string 
Type 
{ 
get  
;  !
set" %
;% &
}' (
=) *
default+ 2
!2 3
;3 4
} 
}

 £!
åD:\Real-Estate\RealEstate.Application\Features\LotClassifications\Commands\CreateLotClassifications\CreateLotClassificationCommandHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
LotClassifications* <
.< =$
CreateLotClassifications= U
{ 
public 

class 1
%CreateLotClassificationCommandHandler 6
:7 8
IRequestHandler9 H
<H I*
CreateLotClassificationCommandI g
,g h3
&CreateLotClassificationCommandResponse	i è
>
è ê
{ 
private		 
readonly		 (
ILotClassificationRepository		 5

repository		6 @
;		@ A
public 1
%CreateLotClassificationCommandHandler 4
(4 5(
ILotClassificationRepository5 Q

repositoryR \
)\ ]
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< 2
&CreateLotClassificationCommandResponse @
>@ A
HandleB H
(H I*
CreateLotClassificationCommandI g
requesth o
,o p
CancellationToken	q Ç
cancellationToken
É î
)
î ï
{ 	
var 
	validator 
= 
new 3
'CreateLotClassificationCommandValidator  G
(G H
)H I
;I J
var 
validationResult  
=! "
await# (
	validator) 2
.2 3
ValidateAsync3 @
(@ A
requestA H
,H I
cancellationTokenJ [
)[ \
;\ ]
if 
( 
! 
validationResult !
.! "
IsValid" )
)) *
{ 
return 
new 2
&CreateLotClassificationCommandResponse A
{ 
Success 
= 
false #
,# $
ValidationErrors $
=% &
validationResult' 7
.7 8
Errors8 >
.> ?
Select? E
(E F
eF G
=>H J
eK L
.L M
ErrorMessageM Y
)Y Z
.Z [
ToList[ a
(a b
)b c
} 
; 
} 
var 
lotClassification !
=" #
LotClassification$ 5
.5 6
Create6 <
(< =
request= D
.D E
TypeE I
)I J
;J K
if   
(   
!   
lotClassification   "
.  " #
	IsSuccess  # ,
)  , -
{!! 
return"" 
new"" 2
&CreateLotClassificationCommandResponse"" A
{## 
Success$$ 
=$$ 
false$$ #
,$$# $
ValidationErrors%% $
=%%% &
new%%' *
List%%+ /
<%%/ 0
string%%0 6
>%%6 7
(%%7 8
)%%8 9
{%%: ;
lotClassification%%< M
.%%M N
Error%%N S
}%%T U
}&& 
;&& 
}'' 
await)) 

repository)) 
.)) 
AddAsync)) %
())% &
lotClassification))& 7
.))7 8
Value))8 =
)))= >
;))> ?
return++ 
new++ 2
&CreateLotClassificationCommandResponse++ =
{,, 
Success-- 
=-- 
true-- 
,-- 
LotClassification.. !
=.." #
new..$ '&
CreateLotClassificationDTO..( B
{// 
Id00 
=00 
lotClassification00 *
.00* +
Value00+ 0
.000 1
Id001 3
,003 4
Type11 
=11 
lotClassification11 ,
.11, -
Value11- 2
.112 3
Type113 7
}22 
}33 
;33 
}44 	
}55 
}66 ¶
çD:\Real-Estate\RealEstate.Application\Features\LotClassifications\Commands\CreateLotClassifications\CreateLotClassificationCommandResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
LotClassifications* <
.< =$
CreateLotClassifications= U
{ 
public 
class 2
&CreateLotClassificationCommandResponse 4
:5 6
BaseResponse7 C
{ 
public 2
&CreateLotClassificationCommandResponse 5
(5 6
)6 7
:8 9
base: >
(> ?
)? @
{ 	
}		 	
public &
CreateLotClassificationDTO )
LotClassification* ;
{< =
get> A
;A B
setC F
;F G
}H I
} 
} Ó
éD:\Real-Estate\RealEstate.Application\Features\LotClassifications\Commands\CreateLotClassifications\CreateLotClassificationCommandValidator.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
LotClassifications* <
.< =$
CreateLotClassifications= U
{ 
public 
class 3
'CreateLotClassificationCommandValidator 5
:6 7
AbstractValidator8 I
<I J*
CreateLotClassificationCommandJ h
>h i
{ 
public 3
'CreateLotClassificationCommandValidator 6
(6 7
)7 8
{ 	
RuleFor		 
(		 
p		 
=>		 
p		 
.		 
Type		 
)		  
.

 
NotEmpty

 
(

 
)

 
.

 
WithMessage

 '
(

' (
$str

( E
)

E F
. 
NotNull 
( 
) 
; 
} 	
} 
} §
ÅD:\Real-Estate\RealEstate.Application\Features\LotClassifications\Commands\CreateLotClassifications\CreateLotClassificationDTO.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
LotClassifications* <
.< =$
CreateLotClassifications= U
{ 
public 
class &
CreateLotClassificationDTO (
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
string 
? 
Type 
{ 
get !
;! "
set# &
;& '
}( )
} 
} à
}D:\Real-Estate\RealEstate.Application\Features\LotClassifications\Commands\DeleteLotClassification\DeleteLotClassification.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
LotClassifications* <
.< =
Command= D
.D E#
DeleteLotClassificationE \
{ 
public 

class #
DeleteLotClassification (
:) *
IRequest+ 3
<3 4+
DeleteLotClassificationResponse4 S
>S T
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
} 
}		 í
ÑD:\Real-Estate\RealEstate.Application\Features\LotClassifications\Commands\DeleteLotClassification\DeleteLotClassificationHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
LotClassifications* <
.< =
Command= D
.D E#
DeleteLotClassificationE \
{ 
public 

class *
DeleteLotClassificationHandler /
:0 1
IRequestHandler2 A
<A B#
DeleteLotClassificationB Y
,Y Z+
DeleteLotClassificationResponse[ z
>z {
{ 
private 
readonly (
ILotClassificationRepository 5

repository6 @
;@ A
public

 *
DeleteLotClassificationHandler

 -
(

- .(
ILotClassificationRepository

. J

repository

K U
)

U V
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< +
DeleteLotClassificationResponse 9
>9 :
Handle; A
(A B#
DeleteLotClassificationB Y
requestZ a
,a b
CancellationTokenc t
cancellationToken	u Ü
)
Ü á
{ 	
var 
result 
= 
await 

repository )
.) *
DeleteAsync* 5
(5 6
request6 =
.= >
Id> @
)@ A
;A B
if 
( 
! 
result 
. 
	IsSuccess !
)! "
{ 
return 
new +
DeleteLotClassificationResponse :
{ 
Success 
= 
false #
,# $
ValidationErrors $
=% &
new' *
List+ /
</ 0
string0 6
>6 7
{8 9
result: @
.@ A
ErrorA F
}G H
} 
; 
} 
return 
new +
DeleteLotClassificationResponse 6
{ 
Success 
= 
true 
} 
; 
} 	
}   
}!! æ
ÖD:\Real-Estate\RealEstate.Application\Features\LotClassifications\Commands\DeleteLotClassification\DeleteLotClassificationResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
LotClassifications* <
.< =
Command= D
.D E#
DeleteLotClassificationE \
{ 
public 

class +
DeleteLotClassificationResponse 0
:1 2
BaseResponse3 ?
{ 
} 
} ˘
ÑD:\Real-Estate\RealEstate.Application\Features\LotClassifications\Commands\UpdateLotClassification\UpdateLotClassificationCommand.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
LotClassifications* <
.< =
Commands= E
.E F#
UpdateLotClassificationF ]
{ 
public 
class *
UpdateLotClassificationCommand ,
:, -
IRequest. 6
<6 72
&UpdateLotClassificationCommandResponse7 ]
>] ^
{ 
public 
Guid	 
Id 
{ 
get 
; 
set 
; 
} 
public 
string	 
Type 
{ 
get 
; 
set 
;  
}! "
=# $
default% ,
!, -
;- .
}		 
}

 ÿ'
ãD:\Real-Estate\RealEstate.Application\Features\LotClassifications\Commands\UpdateLotClassification\UpdateLotClassificationCommandHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
LotClassifications* <
.< =
Commands= E
.E F#
UpdateLotClassificationF ]
{ 
public 
class 1
%UpdateLotClassificationCommandHandler 3
:3 4
IRequestHandler5 D
<D E*
UpdateLotClassificationCommandE c
,c d3
&UpdateLotClassificationCommandResponse	e ã
>
ã å
{ 
private 	
readonly
 (
ILotClassificationRepository /

repository0 :
;: ;
public		 1
%UpdateLotClassificationCommandHandler			 .
(		. /(
ILotClassificationRepository		/ K

repository		L V
)		V W
{

 
this 
. 

repository 
= 

repository 
;  
} 
public 
async	 
Task 
< 2
&UpdateLotClassificationCommandResponse :
>: ;
Handle< B
(B C*
UpdateLotClassificationCommandC a
requestb i
,i j
CancellationTokenk |
cancellationToken	} é
)
é è
{ 
var 
lotClassification 
= 
await  

repository! +
.+ ,
FindByIdAsync, 9
(9 :
request: A
.A B
IdB D
)D E
;E F
var 
	validator 
= 
new 3
'UpdateLotClassificationCommandValidator >
(> ?
)? @
;@ A
var 
validatorResult 
= 
await 
	validator (
.( )
ValidateAsync) 6
(6 7
request7 >
,> ?
cancellationToken@ Q
)Q R
;R S
if 
( 
! 
validatorResult 
. 
IsValid 
)  
{ 
return 

new 2
&UpdateLotClassificationCommandResponse 5
{ 
Success 
= 
false 
, 
ValidationErrors 
= 
validatorResult '
.' (
Errors( .
.. /
Select/ 5
(5 6
e6 7
=>8 :
e; <
.< =
ErrorMessage= I
)I J
.J K
ToListK Q
(Q R
)R S
} 
; 
} 
if 
( 
! 
lotClassification 
. 
	IsSuccess #
)# $
{ 
return 

new 2
&UpdateLotClassificationCommandResponse 5
{ 
Success   
=   
false   
,   
ValidationErrors!! 
=!! 
new!! 
List!!  
<!!  !
string!!! '
>!!' (
(!!( )
)!!) *
{!!+ ,
lotClassification!!- >
.!!> ?
Error!!? D
}!!E F
}"" 
;"" 
}## 
lotClassification%% 
.%% 
Value%% 
.%% 

AttachType%% %
(%%% &
request%%& -
.%%- .
Type%%. 2
)%%2 3
;%%3 4
var&& $
updatedLotClassification&& 
=&&  !
await&&" '

repository&&( 2
.&&2 3
UpdateAsync&&3 >
(&&> ?
lotClassification&&? P
.&&P Q
Value&&Q V
)&&V W
;&&W X
if(( 
((( 
!(( $
updatedLotClassification((  
.((  !
	IsSuccess((! *
)((* +
{)) 
return** 

new** 2
&UpdateLotClassificationCommandResponse** 5
{++ 
Success,, 
=,, 
false,, 
,,, 
ValidationErrors-- 
=-- 
new-- 
List--  
<--  !
string--! '
>--' (
(--( )
)--) *
{--+ ,$
updatedLotClassification--- E
.--E F
Error--F K
}--L M
}.. 
;.. 
}// 
return11 	
new11
 2
&UpdateLotClassificationCommandResponse11 4
{22 
Success33 
=33 
true33 
,33 
LotClassification44 
=44 
new44 &
UpdateLotClassificationDto44 6
{55 
Type66 	
=66
 $
updatedLotClassification66 $
.66$ %
Value66% *
.66* +
Type66+ /
}77 
}88 
;88 
}99 
}:: 
}<< …
åD:\Real-Estate\RealEstate.Application\Features\LotClassifications\Commands\UpdateLotClassification\UpdateLotClassificationCommandResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
LotClassifications* <
.< =
Commands= E
.E F#
UpdateLotClassificationF ]
{ 
public 
class 2
&UpdateLotClassificationCommandResponse 4
:4 5
BaseResponse6 B
{ 
public 2
&UpdateLotClassificationCommandResponse	 /
(/ 0
)0 1
:1 2
base3 7
(7 8
)8 9
{ 
}		 
public

 &
UpdateLotClassificationDto

	 #
LotClassification

$ 5
{

6 7
get

8 ;
;

; <
set

= @
;

@ A
}

B C
} 
} Ù
çD:\Real-Estate\RealEstate.Application\Features\LotClassifications\Commands\UpdateLotClassification\UpdateLotClassificationCommandValidator.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
LotClassifications* <
.< =
Commands= E
.E F#
UpdateLotClassificationF ]
{ 
public 
class 3
'UpdateLotClassificationCommandValidator 5
:5 6
AbstractValidator7 H
<H I*
UpdateLotClassificationCommandI g
>g h
{ 
public 3
'UpdateLotClassificationCommandValidator	 0
(0 1
)1 2
{ 
RuleFor		 

(		
 
p		 
=>		 
p		 
.		 
Id		 
)		 
.

 
NotEmpty

 
(

 
)

 
.

 
WithMessage

 
(

 
$str

 9
)

9 :
. 
NotNull 
( 
) 
. 
NotEqual 
( 
Guid 
. 
Empty 
) 
; 
RuleFor 

(
 
p 
=> 
p 
. 
Type 
) 
. 
NotEmpty 
( 
) 
. 
WithMessage 
( 
$str 9
)9 :
. 
NotNull 
( 
) 
; 
} 
} 
} ≥
ÄD:\Real-Estate\RealEstate.Application\Features\LotClassifications\Commands\UpdateLotClassification\UpdateLotClassificationDto.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
LotClassifications* <
.< =
Commands= E
.E F#
UpdateLotClassificationF ]
{ 
public 
class &
UpdateLotClassificationDto (
{ 
public 
string	 
? 
Type 
{ 
get 
; 
set  
;  !
}" #
} 
} ﬁ
qD:\Real-Estate\RealEstate.Application\Features\LotClassifications\Queries\GetAll\GetAllLotClassificationsQuery.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
LotClassifications* <
.< =
Queries= D
.D E
GetAllE K
{ 
public 

class )
GetAllLotClassificationsQuery .
:/ 0
IRequest1 9
<9 :,
 GetAllLotClassificationsResponse: Z
>Z [
{ 
} 
} ∞
xD:\Real-Estate\RealEstate.Application\Features\LotClassifications\Queries\GetAll\GetAllLotClassificationsQueryHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
LotClassifications* <
.< =
Queries= D
.D E
GetAllE K
{ 
public 

class 0
$GetAllLotClassificationsQueryHandler 5
:6 7
IRequestHandler8 G
<G H)
GetAllLotClassificationsQueryH e
,e f-
 GetAllLotClassificationsResponse	g á
>
á à
{ 
private 
readonly (
ILotClassificationRepository 5

repository6 @
;@ A
public		 0
$GetAllLotClassificationsQueryHandler		 3
(		3 4(
ILotClassificationRepository		4 P

repository		Q [
)		[ \
{

 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< ,
 GetAllLotClassificationsResponse :
>: ;
Handle< B
(B C)
GetAllLotClassificationsQueryC `
requesta h
,h i
CancellationTokenj {
cancellationToken	| ç
)
ç é
{ 	,
 GetAllLotClassificationsResponse ,
response- 5
=6 7
new8 ;
(; <
)< =
;= >
var 
result 
= 
await 

repository )
.) *
GetAllAsync* 5
(5 6
)6 7
;7 8
if 
( 
result 
. 
	IsSuccess 
)  
{ 
response 
. 
LotClassifications +
=, -
result. 4
.4 5
Value5 :
.: ;
Select; A
(A B
lotClassificationB S
=>T V
newW Z 
LotClassificationDto[ o
{ 
Id 
= 
lotClassification *
.* +
Id+ -
,- .
Type 
= 
lotClassification ,
., -
Type- 1
} 
) 
. 
ToList 
( 
) 
; 
} 
return 
response 
; 
} 	
} 
} ◊
tD:\Real-Estate\RealEstate.Application\Features\LotClassifications\Queries\GetAll\GetAllLotClassificationsResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
LotClassifications* <
.< =
Queries= D
.D E
GetAllE K
{ 
public 

class ,
 GetAllLotClassificationsResponse 1
{ 
public 
List 
<  
LotClassificationDto (
>( )
LotClassifications* <
{= >
get? B
;B C
setD G
;G H
}I J
} 
} Ü
rD:\Real-Estate\RealEstate.Application\Features\LotClassifications\Queries\GetById\GetByIdLotClassificationQuery.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
LotClassifications* <
.< =
Queries= D
.D E
GetByIdE L
{ 
public 

record )
GetByIdLotClassificationQuery /
(/ 0
Guid0 4
Id5 7
)7 8
:9 :
IRequest; C
<C D 
LotClassificationDtoD X
>X Y
;Y Z
} ™
yD:\Real-Estate\RealEstate.Application\Features\LotClassifications\Queries\GetById\GetByIdLotClassificationQueryHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
LotClassifications* <
.< =
Queries= D
.D E
GetByIdE L
{ 
public 

class 0
$GetByIdLotClassificationQueryHandler 5
:6 7
IRequestHandler8 G
<G H)
GetByIdLotClassificationQueryH e
,e f 
LotClassificationDtog {
>{ |
{ 
private 
readonly (
ILotClassificationRepository 5

repository6 @
;@ A
public		 0
$GetByIdLotClassificationQueryHandler		 3
(		3 4(
ILotClassificationRepository		4 P

repository		Q [
)		[ \
{

 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
<  
LotClassificationDto .
>. /
Handle0 6
(6 7)
GetByIdLotClassificationQuery7 T
requestU \
,\ ]
CancellationToken^ o
cancellationToken	p Å
)
Å Ç
{ 	
var 
lotClassification !
=" #
await$ )

repository* 4
.4 5
FindByIdAsync5 B
(B C
requestC J
.J K
IdK M
)M N
;N O
if 
( 
lotClassification  
.  !
	IsSuccess! *
)* +
{ 
return 
new  
LotClassificationDto /
{ 
Id 
= 
lotClassification *
.* +
Value+ 0
.0 1
Id1 3
,3 4
Type 
= 
lotClassification ,
., -
Value- 2
.2 3
Type3 7
} 
; 
} 
return 
new  
LotClassificationDto +
(+ ,
), -
;- .
} 	
} 
} ü
aD:\Real-Estate\RealEstate.Application\Features\LotClassifications\Queries\LotClassificationDto.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
LotClassifications* <
.< =
Queries= D
{ 
public 

class  
LotClassificationDto %
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
string 
Type 
{ 
get  
;  !
set" %
;% &
}' (
=) *
default+ 2
!2 3
;3 4
} 
} Å
ZD:\Real-Estate\RealEstate.Application\Features\Lots\Commands\CreateLot\CreateLotCommand.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Lots* .
.. /
Commands/ 7
.7 8
	CreateLot8 A
{ 
public 
class 
CreateLotCommand 
:  
IRequest! )
<) *$
CreateLotCommandResponse* B
>B C
{ 
public 
string 
UserId 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
default- 4
!4 5
;5 6
public 
string 
	TitlePost 
{  !
get" %
;% &
set' *
;* +
}, -
=. /
default0 7
!7 8
;8 9
public		 
double		 
Price		 
{		 
get		 !
;		! "
set		# &
;		& '
}		( )
=		* +
default		, 3
!		3 4
;		4 5
public

 
Guid

 
	AddressId

 
{

 
get

  #
;

# $
set

% (
;

( )
}

* +
=

, -
default

. 5
!

5 6
;

6 7
public 
bool 
	OfferType 
{ 
get  #
;# $
set% (
;( )
}* +
=, -
default. 5
!5 6
;6 7
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
default2 9
!9 :
;: ;
public 
double 
LotArea 
{ 
get  #
;# $
set% (
;( )
}* +
=, -
default. 5
!5 6
;6 7
public 
double 
StreetFrontage $
{% &
get' *
;* +
set, /
;/ 0
}1 2
=3 4
default5 <
!< =
;= >
public 
Guid 
LotClassificationId '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
=6 7
default8 ?
!? @
;@ A
} 
} œ,
aD:\Real-Estate\RealEstate.Application\Features\Lots\Commands\CreateLot\CreateLotCommandHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Lots* .
.. /
Commands/ 7
.7 8
	CreateLot8 A
{ 
public 

class #
CreateLotCommandHandler (
:) *
IRequestHandler+ :
<: ;
CreateLotCommand; K
,K L$
CreateLotCommandResponseM e
>e f
{ 
private		 
readonly		 
ILotRepository		 '

repository		( 2
;		2 3
public #
CreateLotCommandHandler &
(& '
ILotRepository' 5

repository6 @
)@ A
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< $
CreateLotCommandResponse 2
>2 3
Handle4 :
(: ;
CreateLotCommand; K
requestL S
,S T
CancellationTokenU f
cancellationTokeng x
)x y
{ 	
var 
	validator 
= 
new %
CreateLotCommandValidator  9
(9 :
): ;
;; <
var 
validationResult  
=! "
await# (
	validator) 2
.2 3
ValidateAsync3 @
(@ A
requestA H
,H I
cancellationTokenJ [
)[ \
;\ ]
if 
( 
! 
validationResult !
.! "
IsValid" )
)) *
{ 
return 
new $
CreateLotCommandResponse 3
{ 
Success 
= 
false #
,# $
ValidationErrors $
=% &
validationResult' 7
.7 8
Errors8 >
.> ?
Select? E
(E F
eF G
=>H J
eK L
.L M
ErrorMessageM Y
)Y Z
.Z [
ToList[ a
(a b
)b c
} 
; 
} 
var 
lot 
= 
Lot 
. 
Create  
(  !
request! (
.( )
UserId) /
,/ 0
request1 8
.8 9
	TitlePost9 B
,B C
requestD K
.K L
PriceL Q
,Q R
requestS Z
.Z [
	AddressId[ d
,d e
requestf m
.m n
	OfferTypen w
,w x
request	y Ä
.
Ä Å
Description
Å å
,
å ç
request 
. 
LotArea 
,  
request! (
.( )
StreetFrontage) 7
,7 8
request9 @
.@ A
LotClassificationIdA T
)T U
;U V
if!! 
(!! 
!!! 
lot!! 
.!! 
	IsSuccess!! 
)!! 
{"" 
return## 
new## $
CreateLotCommandResponse## 3
{$$ 
Success%% 
=%% 
false%% #
,%%# $
ValidationErrors&& $
=&&% &
new&&' *
List&&+ /
<&&/ 0
string&&0 6
>&&6 7
(&&7 8
)&&8 9
{&&: ;
lot&&< ?
.&&? @
Error&&@ E
}&&F G
}'' 
;'' 
}(( 
await** 

repository** 
.** 
AddAsync** %
(**% &
lot**& )
.**) *
Value*** /
)**/ 0
;**0 1
return,, 
new,, $
CreateLotCommandResponse,, /
{-- 
Success.. 
=.. 
true.. 
,.. 
Lot// 
=// 
new// 
CreateLotDTO// &
{00 

BasePostId11 
=11  
lot11! $
.11$ %
Value11% *
.11* +

BasePostId11+ 5
,115 6
UserId22 
=22 
lot22  
.22  !
Value22! &
.22& '
UserId22' -
,22- .
	TitlePost33 
=33 
lot33  #
.33# $
Value33$ )
.33) *
	TitlePost33* 3
,333 4
Price44 
=44 
lot44 
.44  
Value44  %
.44% &
Price44& +
,44+ ,
	AddressId55 
=55 
lot55  #
.55# $
Value55$ )
.55) *
	AddressId55* 3
,553 4
	OfferType66 
=66 
lot66  #
.66# $
Value66$ )
.66) *
	OfferType66* 3
,663 4
Description77 
=77  !
lot77" %
.77% &
Value77& +
.77+ ,
Description77, 7
,777 8
LotArea88 
=88 
lot88 !
.88! "
Value88" '
.88' (
LotArea88( /
,88/ 0
StreetFrontage99 "
=99# $
lot99% (
.99( )
Value99) .
.99. /
StreetFrontage99/ =
,99= >
LotClassificationId:: '
=::( )
lot::* -
.::- .
Value::. 3
.::3 4
LotClassificationId::4 G
};; 
}<< 
;<< 
}== 	
}>> 
}AA  
bD:\Real-Estate\RealEstate.Application\Features\Lots\Commands\CreateLot\CreateLotCommandResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Lots* .
.. /
Commands/ 7
.7 8
	CreateLot8 A
{ 
public 
class $
CreateLotCommandResponse &
:' (
BaseResponse) 5
{ 
public $
CreateLotCommandResponse '
(' (
)( )
:* +
base, 0
(0 1
)1 2
{ 	
}

 	
public 
CreateLotDTO 
Lot 
{  !
get" %
;% &
set' *
;* +
}, -
} 
} ß"
cD:\Real-Estate\RealEstate.Application\Features\Lots\Commands\CreateLot\CreateLotCommandValidator.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Lots* .
.. /
Commands/ 7
.7 8
	CreateLot8 A
{ 
public 
class %
CreateLotCommandValidator '
:( )
AbstractValidator* ;
<; <
CreateLotCommand< L
>L M
{ 
public %
CreateLotCommandValidator (
(( )
)) *
{ 	
RuleFor		 
(		 
p		 
=>		 
p		 
.		 
UserId		 !
)		! "
.

 
NotEmpty

 
(

 
)

 
.

 
WithMessage

 '
(

' (
$str

( E
)

E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
	TitlePost $
)$ %
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
Price  
)  !
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
. 
GreaterThan 
( 
$num 
) 
.  
WithMessage  +
(+ ,
$str, T
)T U
;U V
RuleFor 
( 
p 
=> 
p 
. 
	AddressId $
)$ %
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
	OfferType $
)$ %
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
Description &
)& '
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
.   
NotNull   
(   
)   
.!! 
MaximumLength!! 
(!! 
$num!! #
)!!# $
.!!$ %
WithMessage!!% 0
(!!0 1
$str!!1 b
)!!b c
;!!c d
RuleFor## 
(## 
p## 
=>## 
p## 
.## 
LotArea## "
)##" #
.$$ 
NotEmpty$$ 
($$ 
)$$ 
.$$ 
WithMessage$$ '
($$' (
$str$$( E
)$$E F
.%% 
NotNull%% 
(%% 
)%% 
;%% 
RuleFor'' 
('' 
p'' 
=>'' 
p'' 
.'' 
StreetFrontage'' )
)'') *
.(( 
NotEmpty(( 
((( 
)(( 
.(( 
WithMessage(( '
(((' (
$str((( E
)((E F
.)) 
NotNull)) 
()) 
))) 
;)) 
RuleFor++ 
(++ 
p++ 
=>++ 
p++ 
.++ 
LotClassificationId++ .
)++. /
.,, 
NotEmpty,, 
(,, 
),, 
.,, 
WithMessage,, '
(,,' (
$str,,( E
),,E F
.-- 
NotNull-- 
(-- 
)-- 
;-- 
}.. 	
}// 
}00 æ
VD:\Real-Estate\RealEstate.Application\Features\Lots\Commands\CreateLot\CreateLotDTO.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Lots* .
.. /
Commands/ 7
.7 8
	CreateLot8 A
{ 
public 
class 
CreateLotDTO 
{ 
public 
Guid 

BasePostId 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
UserId 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
default- 4
!4 5
;5 6
public 
string 
	TitlePost 
{  !
get" %
;% &
set' *
;* +
}, -
=. /
default0 7
!7 8
;8 9
public 
double 
Price 
{ 
get !
;! "
set# &
;& '
}( )
public		 
Guid		 
	AddressId		 
{		 
get		  #
;		# $
set		% (
;		( )
}		* +
public

 
bool

 
	OfferType

 
{

 
get

  #
;

# $
set

% (
;

( )
}

* +
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
default2 9
!9 :
;: ;
public 
double 
? 
LotArea 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
double 
? 
StreetFrontage %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 
Guid 
LotClassificationId '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
} 
} Ø
SD:\Real-Estate\RealEstate.Application\Features\Lots\Commands\DeleteLot\DeleteLot.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Lots* .
.. /
Commands/ 7
.7 8
	DeleteLot8 A
{ 
public 

class 
	DeleteLot 
: 
IRequest %
<% &
DeleteLotResponse& 7
>7 8
{ 
public 
Guid 

BasePostId 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
}		 ≈
ZD:\Real-Estate\RealEstate.Application\Features\Lots\Commands\DeleteLot\DeleteLotHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Lots* .
.. /
Commands/ 7
.7 8
	DeleteLot8 A
{ 
public 

class 
DeleteLotHandler !
:" #
IRequestHandler$ 3
<3 4
	DeleteLot4 =
,= >
DeleteLotResponse? P
>P Q
{ 
private 
readonly 
ILotRepository '

repository( 2
;2 3
public

 
DeleteLotHandler

 
(

  
ILotRepository

  .

repository

/ 9
)

9 :
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< 
DeleteLotResponse +
>+ ,
Handle- 3
(3 4
	DeleteLot4 =
request> E
,E F
CancellationTokenG X
cancellationTokenY j
)j k
{ 	
var 
result 
= 
await 

repository )
.) *
DeleteAsync* 5
(5 6
request6 =
.= >

BasePostId> H
)H I
;I J
if 
( 
! 
result 
. 
	IsSuccess !
)! "
{ 
return 
new 
DeleteLotResponse ,
{ 
Success 
= 
false #
,# $
ValidationErrors $
=% &
new' *
List+ /
</ 0
string0 6
>6 7
{8 9
result: @
.@ A
ErrorA F
}G H
} 
; 
} 
return 
new 
DeleteLotResponse (
{ 
Success 
= 
true 
} 
; 
} 	
}   
}!! Í
[D:\Real-Estate\RealEstate.Application\Features\Lots\Commands\DeleteLot\DeleteLotResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Lots* .
.. /
Commands/ 7
.7 8
	DeleteLot8 A
{ 
public 

class 
DeleteLotResponse "
:# $
BaseResponse% 1
{ 
} 
} €
ZD:\Real-Estate\RealEstate.Application\Features\Lots\Commands\UpdateLot\UpdateLotCommand.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Lots* .
.. /
Commands/ 7
.7 8
	UpdateLot8 A
{ 
public 
class 
UpdateLotCommand 
: 
IRequest  (
<( )$
UpdateLotCommandResponse) A
>A B
{ 
public 
Guid 

BasePostId 
{  
get! $
;$ %
set& )
;) *
}+ ,
public		 
string		 
UserId		 
{		 
get		 "
;		" #
set		$ '
;		' (
}		) *
=		+ ,
default		- 4
!		4 5
;		5 6
public

 
string

 
	TitlePost

 
{

  !
get

" %
;

% &
set

' *
;

* +
}

, -
=

. /
default

0 7
!

7 8
;

8 9
public 
double 
Price 
{ 
get !
;! "
set# &
;& '
}( )
=* +
default, 3
!3 4
;4 5
public 
Guid 
	AddressId 
{ 
get  #
;# $
set% (
;( )
}* +
=, -
default. 5
!5 6
;6 7
public 
bool 
	OfferType 
{ 
get  #
;# $
set% (
;( )
}* +
=, -
default. 5
!5 6
;6 7
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
default2 9
!9 :
;: ;
public 
double	 
LotArea 
{ 
get 
; 
set "
;" #
}$ %
=& '
default( /
!/ 0
;0 1
public 
double	 
StreetFrontage 
{  
get! $
;$ %
set& )
;) *
}+ ,
=- .
default/ 6
!6 7
;7 8
public 
Guid 
LotClassificationId '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
} 
} Ó;
aD:\Real-Estate\RealEstate.Application\Features\Lots\Commands\UpdateLot\UpdateLotCommandHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Lots* .
.. /
Commands/ 7
.7 8
	UpdateLot8 A
{ 
public 
class #
UpdateLotCommandHandler %
:& '
IRequestHandler( 7
<7 8
UpdateLotCommand8 H
,H I$
UpdateLotCommandResponseJ b
>b c
{ 
private		 	
readonly		
 
ILotRepository		 !

repository		" ,
;		, -
public

 #
UpdateLotCommandHandler

	  
(

  !
ILotRepository

! /

repository

0 :
)

: ;
{ 
this 
. 

repository 
= 

repository 
;  
} 
public 
async	 
Task 
< $
UpdateLotCommandResponse ,
>, -
Handle. 4
(4 5
UpdateLotCommand5 E
requestF M
,M N
CancellationTokenO `
cancellationTokena r
)r s
{ 
var 
lot 

= 
await 

repository 
. 
FindByIdAsync +
(+ ,
request, 3
.3 4

BasePostId4 >
)> ?
;? @
var 
	validator 
= 
new %
UpdateLotCommandValidator 0
(0 1
)1 2
;2 3
var 
validatorResult 
= 
await 
	validator (
.( )
ValidateAsync) 6
(6 7
request7 >
,> ?
cancellationToken@ Q
)Q R
;R S
if 
( 
! 
validatorResult 
. 
IsValid 
)  
{ 
return 

new $
UpdateLotCommandResponse '
{ 
Success 
= 
false 
, 
ValidationErrors 
= 
validatorResult '
.' (
Errors( .
.. /
Select/ 5
(5 6
e6 7
=>8 :
e; <
.< =
ErrorMessage= I
)I J
.J K
ToListK Q
(Q R
)R S
} 
; 
} 
if 
( 
! 
lot 
. 
	IsSuccess 
) 
{ 
return 

new $
UpdateLotCommandResponse '
{   
Success!! 
=!! 
false!! 
,!! 
ValidationErrors"" 
="" 
new"" 
List""  
<""  !
string""! '
>""' (
(""( )
)"") *
{""+ ,
lot""- 0
.""0 1
Error""1 6
}""7 8
}## 
;## 
}$$ 
lot&& 
.&& 
Value&& 
.&& 
AttachLotArea&& 
(&& 
request&& "
.&&" #
LotArea&&# *
)&&* +
;&&+ ,
lot'' 
.'' 
Value'' 
.''  
AttachStreetFrontage'' !
(''! "
request''" )
.'') *
StreetFrontage''* 8
)''8 9
;''9 :
lot(( 
.(( 
Value(( 
.(( %
AttachLotClassificationId(( &
(((& '
request((' .
.((. /
LotClassificationId((/ B
)((B C
;((C D
lot)) 
.)) 
Value)) 
.)) 
AttachUserId)) "
())" #
request))# *
.))* +
UserId))+ 1
)))1 2
;))2 3
lot** 
.** 
Value** 
.** 
AttachTitlePost** %
(**% &
request**& -
.**- .
	TitlePost**. 7
)**7 8
;**8 9
lot++ 
.++ 
Value++ 
.++ 
AttachPrice++ !
(++! "
request++" )
.++) *
Price++* /
)++/ 0
;++0 1
lot,, 
.,, 
Value,, 
.,, 
AttachAddressId,, %
(,,% &
request,,& -
.,,- .
	AddressId,,. 7
),,7 8
;,,8 9
lot-- 
.-- 
Value-- 
.-- 
AttachOfferType-- %
(--% &
request--& -
.--- .
	OfferType--. 7
)--7 8
;--8 9
lot.. 
... 
Value.. 
... 
AttachDescription.. 
(.. 
request.. &
...& '
Description..' 2
)..2 3
;..3 4
var00 

updatedLot00 
=00 
await00 "

repository00# -
.00- .
UpdateAsync00. 9
(009 :
lot00: =
.00= >
Value00> C
)00C D
;00D E
if22 
(22 
!22 

updatedLot22 
.22 
	IsSuccess22 
)22 
{33 
return44 

new44 $
UpdateLotCommandResponse44 '
{55 
Success66 
=66 
false66 
,66 
ValidationErrors77 
=77 
new77 
List77  
<77  !
string77! '
>77' (
(77( )
)77) *
{77+ ,

updatedLot77- 7
.777 8
Error778 =
}77> ?
}88 
;88 
}99 
return;; 	
new;;
 $
UpdateLotCommandResponse;; &
{<< 
Success== 
=== 
true== 
,== 
Lot>> 
=>> 	
new>>
 
UpdateLotDto>> 
{?? 

BasePostId@@ 
=@@ 

updatedLot@@ 
.@@ 
Value@@ "
.@@" #

BasePostId@@# -
,@@- .
UserIdAA 
=AA 

updatedLotAA 
.AA 
ValueAA 
.AA 
UserIdAA %
,AA% &
	TitlePostBB 
=BB 

updatedLotBB 
.BB 
ValueBB !
.BB! "
	TitlePostBB" +
,BB+ ,
PriceCC 

=CC 

updatedLotCC 
.CC 
ValueCC 
.CC 
PriceCC #
,CC# $
	AddressIdDD 
=DD 

updatedLotDD 
.DD 
ValueDD !
.DD! "
	AddressIdDD" +
,DD+ ,
	OfferTypeEE 
=EE 

updatedLotEE 
.EE 
ValueEE !
.EE! "
	OfferTypeEE" +
,EE+ ,
DescriptionFF 
=FF 

updatedLotFF 
.FF 
ValueFF #
.FF# $
DescriptionFF$ /
,FF/ 0
LotClassificationIdGG 
=GG 

updatedLotGG %
.GG% &
ValueGG& +
.GG+ ,
LotClassificationIdGG, ?
,GG? @
LotAreaHH 
=HH 

updatedLotHH 
.HH 
ValueHH 
.HH  
LotAreaHH  '
,HH' (
StreetFrontageII 
=II 

updatedLotII  
.II  !
ValueII! &
.II& '
StreetFrontageII' 5
}JJ 
}KK 
;KK 
}MM 
}NN 
}OO  
bD:\Real-Estate\RealEstate.Application\Features\Lots\Commands\UpdateLot\UpdateLotCommandResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Lots* .
.. /
Commands/ 7
.7 8
	UpdateLot8 A
{ 
public 
class $
UpdateLotCommandResponse &
:& '
BaseResponse( 4
{ 
public $
UpdateLotCommandResponse	 !
(! "
)" #
:$ %
base& *
(* +
)+ ,
{ 
}		 
public

 
UpdateLotDto

	 
Lot

 
{

 
get

 
;

  
set

! $
;

$ %
}

& '
} 
} £'
cD:\Real-Estate\RealEstate.Application\Features\Lots\Commands\UpdateLot\UpdateLotCommandValidator.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Lots* .
.. /
Commands/ 7
.7 8
	UpdateLot8 A
{ 
public 
class %
UpdateLotCommandValidator '
:' (
AbstractValidator) :
<: ;
UpdateLotCommand; K
>K L
{ 
public %
UpdateLotCommandValidator	 "
(" #
)# $
{ 
RuleFor		 
(		 
p		 
=>		 
p		 
.		 

BasePostId		 %
)		% &
.

 
NotEmpty

 
(

 
)

 
.

 
WithMessage

 '
(

' (
$str

( E
)

E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
UserId !
)! "
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
	TitlePost $
)$ %
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
Price  
)  !
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
. 
GreaterThan 
( 
$num 
) 
.  
WithMessage  +
(+ ,
$str, T
)T U
;U V
RuleFor 
( 
p 
=> 
p 
. 
	AddressId $
)$ %
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
. 
NotNull 
( 
) 
; 
RuleFor 
( 
p 
=> 
p 
. 
	OfferType $
)$ %
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$str( E
)E F
.   
NotNull   
(   
)   
;   
RuleFor"" 
("" 
p"" 
=>"" 
p"" 
."" 
Description"" &
)""& '
.## 
NotEmpty## 
(## 
)## 
.## 
WithMessage## '
(##' (
$str##( E
)##E F
.$$ 
NotNull$$ 
($$ 
)$$ 
.%% 
MaximumLength%% 
(%% 
$num%% #
)%%# $
.%%$ %
WithMessage%%% 0
(%%0 1
$str%%1 b
)%%b c
;%%c d
RuleFor'' 
('' 
p'' 
=>'' 
p'' 
.'' 
LotClassificationId'' .
)''. /
.(( 
NotEmpty(( 
((( 
)(( 
.(( 
WithMessage(( 
((( 
$str(( 9
)((9 :
.)) 
NotNull)) 
()) 
))) 
.)) 
WithMessage)) 
()) 
$str)) 8
)))8 9
;))9 :
RuleFor++ 

(++
 
p++ 
=>++ 
p++ 
.++ 
LotArea++ 
)++ 
.,, 
NotEmpty,, 
(,, 
),, 
.,, 
WithMessage,, 
(,, 
$str,, 9
),,9 :
.-- 
NotNull-- 
(-- 
)-- 
.-- 
WithMessage-- 
(-- 
$str-- 8
)--8 9
;--9 :
RuleFor// 

(//
 
p// 
=>// 
p// 
.// 
StreetFrontage//  
)//  !
.00 
NotEmpty00 
(00 
)00 
.00 
WithMessage00 
(00 
$str00 9
)009 :
.11 
NotNull11 
(11 
)11 
.11 
WithMessage11 
(11 
$str11 8
)118 9
;119 :
}22 
}33 
}44 æ
VD:\Real-Estate\RealEstate.Application\Features\Lots\Commands\UpdateLot\UpdateLotDto.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Lots* .
.. /
Commands/ 7
.7 8
	UpdateLot8 A
{ 
public 
class 
UpdateLotDto 
{ 
public 
Guid 

BasePostId 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
UserId 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
default- 4
!4 5
;5 6
public		 
string		 
	TitlePost		 
{		  !
get		" %
;		% &
set		' *
;		* +
}		, -
=		. /
default		0 7
!		7 8
;		8 9
public

 
double

 
Price

 
{

 
get

 !
;

! "
set

# &
;

& '
}

( )
public 
Guid 
	AddressId 
{ 
get  #
;# $
set% (
;( )
}* +
public 
bool 
	OfferType 
{ 
get  #
;# $
set% (
;( )
}* +
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
default2 9
!9 :
;: ;
public 
double	 
? 
LotArea 
{ 
get 
; 
set  #
;# $
}% &
public 
double	 
? 
StreetFrontage 
{  !
get" %
;% &
set' *
;* +
}, -
public 
Guid 
LotClassificationId '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
} 
} ò
UD:\Real-Estate\RealEstate.Application\Features\Lots\Queries\GetAll\GetAllLotsQuery.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Lots* .
.. /
Queries/ 6
.6 7
GetAll7 =
{ 
public 

class 
GetAllLotsQuery  
:! "
IRequest# +
<+ ,
GetAllLotsResponse, >
>> ?
{ 
} 
} ∆
\D:\Real-Estate\RealEstate.Application\Features\Lots\Queries\GetAll\GetAllLotsQueryHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Lots* .
.. /
Queries/ 6
.6 7
GetAll7 =
{ 
public 

class "
GetAllLotsQueryHandler '
:( )
IRequestHandler* 9
<9 :
GetAllLotsQuery: I
,I J
GetAllLotsResponseK ]
>] ^
{ 
private 
readonly 
ILotRepository '

repository( 2
;2 3
public

 "
GetAllLotsQueryHandler

 %
(

% &
ILotRepository

& 4

repository

5 ?
)

? @
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< 
GetAllLotsResponse ,
>, -
Handle. 4
(4 5
GetAllLotsQuery5 D
requestE L
,L M
CancellationTokenN _
cancellationToken` q
)q r
{ 	
GetAllLotsResponse 
response '
=( )
new* -
(- .
). /
;/ 0
var 
result 
= 
await 

repository )
.) *
GetAllAsync* 5
(5 6
)6 7
;7 8
if 
( 
result 
. 
	IsSuccess 
)  
{ 
response 
. 
Lots 
= 
result  &
.& '
Value' ,
., -
Select- 3
(3 4
lot4 7
=>8 :
new; >
LotDto? E
{ 

BasePostId 
=  
lot! $
.$ %

BasePostId% /
,/ 0
UserId 
= 
lot  
.  !
UserId! '
,' (
	TitlePost 
= 
lot  #
.# $
	TitlePost$ -
,- .
Price 
= 
lot 
.  
Price  %
,% &
	AddressId 
= 
lot  #
.# $
	AddressId$ -
,- .
	OfferType 
= 
lot  #
.# $
	OfferType$ -
,- .
Description 
=  !
lot" %
.% &
Description& 1
,1 2
LotArea 
= 
lot !
.! "
LotArea" )
,) *
StreetFrontage   "
=  # $
lot  % (
.  ( )
StreetFrontage  ) 7
,  7 8
LotClassificationId!! '
=!!( )
lot!!* -
.!!- .
LotClassificationId!!. A
}"" 
)"" 
."" 
ToList"" 
("" 
)"" 
;"" 
}## 
return$$ 
response$$ 
;$$ 
}%% 	
}&& 
}'' É
XD:\Real-Estate\RealEstate.Application\Features\Lots\Queries\GetAll\GetAllLotsResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Lots* .
.. /
Queries/ 6
.6 7
GetAll7 =
{ 
public 

class 
GetAllLotsResponse #
{ 
public 
List 
< 
LotDto 
> 
Lots  
{! "
get# &
;& '
set( +
;+ ,
}- .
} 
} ¿
VD:\Real-Estate\RealEstate.Application\Features\Lots\Queries\GetById\GetByIdLotQuery.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Lots* .
.. /
Queries/ 6
.6 7
GetById7 >
{ 
public 

record 
GetByIdLotQuery !
(! "
Guid" &
Id' )
)) *
:+ ,
IRequest- 5
<5 6
LotDto6 <
>< =
;= >
} ”
]D:\Real-Estate\RealEstate.Application\Features\Lots\Queries\GetById\GetByIdLotQueryHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Lots* .
.. /
Queries/ 6
.6 7
GetById7 >
{ 
public 

class "
GetByIdLotQueryHandler '
:( )
IRequestHandler* 9
<9 :
GetByIdLotQuery: I
,I J
LotDtoK Q
>Q R
{ 
private 
readonly 
ILotRepository '

repository( 2
;2 3
public

 "
GetByIdLotQueryHandler

 %
(

% &
ILotRepository

& 4

repository

5 ?
)

? @
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< 
LotDto  
>  !
Handle" (
(( )
GetByIdLotQuery) 8
request9 @
,@ A
CancellationTokenB S
cancellationTokenT e
)e f
{ 	
var 
lot 
= 
await 

repository &
.& '
FindByIdAsync' 4
(4 5
request5 <
.< =
Id= ?
)? @
;@ A
if 
( 
lot 
. 
	IsSuccess 
) 
{ 
return 
new 
LotDto !
{ 

BasePostId 
=  
lot! $
.$ %
Value% *
.* +

BasePostId+ 5
,5 6
UserId 
= 
lot  
.  !
Value! &
.& '
UserId' -
,- .
	TitlePost 
= 
lot  #
.# $
Value$ )
.) *
	TitlePost* 3
,3 4
Price 
= 
lot 
.  
Value  %
.% &
Price& +
,+ ,
	AddressId 
= 
lot  #
.# $
Value$ )
.) *
	AddressId* 3
,3 4
	OfferType 
= 
lot  #
.# $
Value$ )
.) *
	OfferType* 3
,3 4
Description 
=  !
lot" %
.% &
Value& +
.+ ,
Description, 7
,7 8
LotArea 
= 
lot !
.! "
Value" '
.' (
LotArea( /
,/ 0
StreetFrontage "
=# $
lot% (
.( )
Value) .
.. /
StreetFrontage/ =
,= >
LotClassificationId   '
=  ( )
lot  * -
.  - .
Value  . 3
.  3 4
LotClassificationId  4 G
}!! 
;!! 
}"" 
return## 
new## 
LotDto## 
(## 
)## 
;##  
}$$ 	
}%% 
}&& ¨
ED:\Real-Estate\RealEstate.Application\Features\Lots\Queries\LotDto.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Lots* .
.. /
Queries/ 6
{ 
public 

class 
LotDto 
{ 
public 
Guid 

BasePostId 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
UserId 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
default- 4
!4 5
;5 6
public 
string 
	TitlePost 
{  !
get" %
;% &
set' *
;* +
}, -
=. /
default0 7
!7 8
;8 9
public 
double 
Price 
{ 
get !
;! "
set# &
;& '
}( )
=* +
default, 3
!3 4
;4 5
public		 
Guid		 
	AddressId		 
{		 
get		  #
;		# $
set		% (
;		( )
}		* +
=		, -
default		. 5
!		5 6
;		6 7
public

 
bool

 
	OfferType

 
{

 
get

  #
;

# $
set

% (
;

( )
}

* +
=

, -
default

. 5
!

5 6
;

6 7
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
default2 9
!9 :
;: ;
public 
double 
LotArea 
{ 
get  #
;# $
set% (
;( )
}* +
=, -
default. 5
!5 6
;6 7
public 
double 
StreetFrontage $
{% &
get' *
;* +
set, /
;/ 0
}1 2
=3 4
default5 <
!< =
;= >
public 
Guid 
LotClassificationId '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
} 
} ¡
uD:\Real-Estate\RealEstate.Application\Features\Partitionings\Commands\CreatePartitioning\CreatePartitioningCommand.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Partitionings* 7
.7 8
Commands8 @
.@ A
CreatePartitioningA S
{ 
public 

class %
CreatePartitioningCommand *
:+ ,
IRequest- 5
<5 6-
!CreatePartitioningCommandResponse6 W
>W X
{ 
public 
string 
Type 
{ 
get  
;  !
set" %
;% &
}' (
=) *
default+ 2
!2 3
;3 4
} 
}		 ¡ 
|D:\Real-Estate\RealEstate.Application\Features\Partitionings\Commands\CreatePartitioning\CreatePartitioningCommandHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Partitionings* 7
.7 8
Commands8 @
.@ A
CreatePartitioningA S
{ 
public 

class ,
 CreatePartitioningCommandHandler 1
:2 3
IRequestHandler4 C
<C D%
CreatePartitioningCommandD ]
,] ^.
!CreatePartitioningCommandResponse	_ Ä
>
Ä Å
{ 
private		 
readonly		 #
IPartitioningRepository		 0

repository		1 ;
;		; <
public

 ,
 CreatePartitioningCommandHandler

 /
(

/ 0#
IPartitioningRepository

0 G

repository

H R
)

R S
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< -
!CreatePartitioningCommandResponse ;
>; <
Handle= C
(C D%
CreatePartitioningCommandD ]
request^ e
,e f
CancellationTokeng x
cancellationToken	y ä
)
ä ã
{ 	
var 
	validator 
= 
new .
"CreatePartitioningCommandValidator  B
(B C
)C D
;D E
var 
validationResult  
=! "
await# (
	validator) 2
.2 3
ValidateAsync3 @
(@ A
requestA H
,H I
cancellationTokenJ [
)[ \
;\ ]
if 
( 
! 
validationResult !
.! "
IsValid" )
)) *
{ 
return 
new -
!CreatePartitioningCommandResponse <
{ 
Success 
= 
false #
,# $
ValidationErrors $
=% &
validationResult' 7
.7 8
Errors8 >
.> ?
Select? E
(E F
eF G
=>H J
eK L
.L M
ErrorMessageM Y
)Y Z
.Z [
ToList[ a
(a b
)b c
} 
; 
} 
var 
partitioning 
= 
Partitioning +
.+ ,
Create, 2
(2 3
request3 :
.: ;
Type; ?
)? @
;@ A
if 
( 
! 
partitioning 
. 
	IsSuccess '
)' (
{ 
return   
new   -
!CreatePartitioningCommandResponse   <
{!! 
Success"" 
="" 
false"" #
,""# $
ValidationErrors## $
=##% &
new##' *
List##+ /
<##/ 0
string##0 6
>##6 7
(##7 8
)##8 9
{##: ;
partitioning##< H
.##H I
Error##I N
}##O P
}$$ 
;$$ 
}%% 
await&& 

repository&& 
.&& 
AddAsync&& %
(&&% &
partitioning&&& 2
.&&2 3
Value&&3 8
)&&8 9
;&&9 :
return(( 
new(( -
!CreatePartitioningCommandResponse(( 8
{)) 
Success** 
=** 
true** 
,** 
Partitioning++ 
=++ 
new++ "!
CreatePartitioningDTO++# 8
{,, 
Id-- 
=-- 
partitioning-- %
.--% &
Value--& +
.--+ ,
Id--, .
,--. /
Type.. 
=.. 
partitioning.. '
...' (
Value..( -
...- .
Type... 2
}// 
}00 
;00 
}11 	
}22 
}33 õ
}D:\Real-Estate\RealEstate.Application\Features\Partitionings\Commands\CreatePartitioning\CreatePartitioningCommandResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Partitionings* 7
.7 8
Commands8 @
.@ A
CreatePartitioningA S
{ 
public 

class -
!CreatePartitioningCommandResponse 2
:3 4
BaseResponse5 A
{ 
public -
!CreatePartitioningCommandResponse 0
(0 1
)1 2
:3 4
base5 9
(9 :
): ;
{ 	
}		 	
public !
CreatePartitioningDTO $
Partitioning% 1
{2 3
get4 7
;7 8
set9 <
;< =
}> ?
} 
} Ë
~D:\Real-Estate\RealEstate.Application\Features\Partitionings\Commands\CreatePartitioning\CreatePartitioningCommandValidator.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Partitionings* 7
.7 8
Commands8 @
.@ A
CreatePartitioningA S
{ 
public 

class .
"CreatePartitioningCommandValidator 3
:4 5
AbstractValidator6 G
<G H%
CreatePartitioningCommandH a
>a b
{ 
public .
"CreatePartitioningCommandValidator 1
(1 2
)2 3
{ 	
RuleFor		 
(		 
p		 
=>		 
p		 
.		 
Type		 
)		  
.

 
NotEmpty

 
(

 
)

 
.

 
WithMessage

 '
(

' (
$str

( E
)

E F
. 
NotNull 
( 
) 
; 
} 	
} 
} ®
qD:\Real-Estate\RealEstate.Application\Features\Partitionings\Commands\CreatePartitioning\CreatePartitioningDTO.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Partitionings* 7
.7 8
Commands8 @
.@ A
CreatePartitioningA S
{ 
public 

class !
CreatePartitioningDTO &
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
string 
? 
Type 
{ 
get !
;! "
set# &
;& '
}( )
} 
} Ê
nD:\Real-Estate\RealEstate.Application\Features\Partitionings\Commands\DeletePartitioning\DeletePartitioning.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Partitionings* 7
.7 8
Commands8 @
.@ A
DeletePartitioningA S
{ 
public 

class 
DeletePartitioning #
:$ %
IRequest& .
<. /&
DeletePartitioningResponse/ I
>I J
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
} 
}		 ƒ
uD:\Real-Estate\RealEstate.Application\Features\Partitionings\Commands\DeletePartitioning\DeletePartitioningHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Partitionings* 7
.7 8
Commands8 @
.@ A
DeletePartitioningA S
{ 
public 

class %
DeletePartitioningHandler *
:+ ,
IRequestHandler- <
<< =
DeletePartitioning= O
,O P&
DeletePartitioningResponseQ k
>k l
{ 
private 
readonly #
IPartitioningRepository 0

repository1 ;
;; <
public

 %
DeletePartitioningHandler

 (
(

( )#
IPartitioningRepository

) @

repository

A K
)

K L
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< &
DeletePartitioningResponse 4
>4 5
Handle6 <
(< =
DeletePartitioning= O
requestP W
,W X
CancellationTokenY j
cancellationTokenk |
)| }
{ 	
var 
result 
= 
await 

repository )
.) *
DeleteAsync* 5
(5 6
request6 =
.= >
Id> @
)@ A
;A B
if 
( 
! 
result 
. 
	IsSuccess !
)! "
{ 
return 
new &
DeletePartitioningResponse 5
{ 
Success 
= 
false #
,# $
ValidationErrors $
=% &
new' *
List+ /
</ 0
string0 6
>6 7
{8 9
result: @
.@ A
ErrorA F
}G H
} 
; 
} 
return 
new &
DeletePartitioningResponse 1
{ 
Success 
= 
true 
} 
; 
} 	
}   
}!! †
vD:\Real-Estate\RealEstate.Application\Features\Partitionings\Commands\DeletePartitioning\DeletePartitioningResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Partitionings* 7
.7 8
Commands8 @
.@ A
DeletePartitioningA S
{ 
public 

class &
DeletePartitioningResponse +
:, -
BaseResponse. :
{ 
} 
} ’
uD:\Real-Estate\RealEstate.Application\Features\Partitionings\Commands\UpdatePartitioning\UpdatePartitioningCommand.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Partitionings* 7
.7 8
Commands8 @
.@ A
UpdatePartitioningA S
{ 
public 
class %
UpdatePartitioningCommand '
:' (
IRequest) 1
<1 2-
!UpdatePartitioningCommandResponse2 S
>S T
{ 
public 
Guid	 
Id 
{ 
get 
; 
set 
; 
} 
public 
string	 
Type 
{ 
get 
; 
set 
;  
}! "
=# $
default% ,
!, -
;- .
}

 
} √&
|D:\Real-Estate\RealEstate.Application\Features\Partitionings\Commands\UpdatePartitioning\UpdatePartitioningCommandHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Partitionings* 7
.7 8
Commands8 @
.@ A
UpdatePartitioningA S
{ 
public 
class ,
 UpdatePartitioningCommandHandler .
:. /
IRequestHandler0 ?
<? @%
UpdatePartitioningCommand@ Y
,Y Z-
!UpdatePartitioningCommandResponse[ |
>| }
{ 
private 	
readonly
 #
IPartitioningRepository *

repository+ 5
;5 6
public		 ,
 UpdatePartitioningCommandHandler			 )
(		) *#
IPartitioningRepository		* A

repository		B L
)		L M
{

 
this 
. 

repository 
= 

repository 
;  
} 
public 
async	 
Task 
< -
!UpdatePartitioningCommandResponse 5
>5 6
Handle7 =
(= >%
UpdatePartitioningCommand> W
requestX _
,_ `
CancellationTokena r
cancellationToken	s Ñ
)
Ñ Ö
{ 
var 
partitioning 
= 
await 

repository &
.& '
FindByIdAsync' 4
(4 5
request5 <
.< =
Id= ?
)? @
;@ A
var 
	validator 
= 
new .
"UpdatePartitioningCommandValidator 9
(9 :
): ;
;; <
var 
validatorResult 
= 
await 
	validator (
.( )
ValidateAsync) 6
(6 7
request7 >
,> ?
cancellationToken@ Q
)Q R
;R S
if 
( 
! 
validatorResult 
. 
IsValid 
)  
{ 
return 

new -
!UpdatePartitioningCommandResponse 0
{ 
Success 
= 
false 
, 
ValidationErrors 
= 
validatorResult '
.' (
Errors( .
.. /
Select/ 5
(5 6
e6 7
=>8 :
e; <
.< =
ErrorMessage= I
)I J
.J K
ToListK Q
(Q R
)R S
} 
; 
} 
if 
( 
! 
partitioning 
. 
	IsSuccess 
) 
{ 
return 

new -
!UpdatePartitioningCommandResponse 0
{ 
Success   
=   
false   
,   
ValidationErrors!! 
=!! 
new!! 
List!!  
<!!  !
string!!! '
>!!' (
(!!( )
)!!) *
{!!+ ,
partitioning!!- 9
.!!9 :
Error!!: ?
}!!@ A
}"" 
;"" 
}## 
partitioning%% 
.%% 
Value%% 
.%% 

AttachType%%  
(%%  !
request%%! (
.%%( )
Type%%) -
)%%- .
;%%. /
var&& 
updatedPartitioning&& 
=&& 
await&& "

repository&&# -
.&&- .
UpdateAsync&&. 9
(&&9 :
partitioning&&: F
.&&F G
Value&&G L
)&&L M
;&&M N
if(( 
((( 
!(( 
updatedPartitioning(( 
.(( 
	IsSuccess(( $
)(($ %
{)) 
return** 

new** -
!UpdatePartitioningCommandResponse** 0
{++ 
Success,, 
=,, 
false,, 
,,, 
ValidationErrors-- 
=-- 
new-- 
List--  
<--  !
string--! '
>--' (
(--( )
)--) *
{--+ ,
updatedPartitioning--- @
.--@ A
Error--A F
}--G H
}.. 
;.. 
}// 
return11 	
new11
 -
!UpdatePartitioningCommandResponse11 /
{22 
Success33 
=33 
true33 
,33 
Partitioning44 
=44 
new44 !
UpdatePartitioningDto44 ,
{55 
Type66 	
=66
 
updatedPartitioning66 
.66  
Value66  %
.66% &
Type66& *
}77 
}88 
;88 
}99 
}:: 
};; õ
}D:\Real-Estate\RealEstate.Application\Features\Partitionings\Commands\UpdatePartitioning\UpdatePartitioningCommandResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Partitionings* 7
.7 8
Commands8 @
.@ A
UpdatePartitioningA S
{ 
public 
class -
!UpdatePartitioningCommandResponse /
:/ 0
BaseResponse1 =
{ 
public -
!UpdatePartitioningCommandResponse	 *
(* +
)+ ,
:, -
base. 2
(2 3
)3 4
{ 
}

 
public !
UpdatePartitioningDto	 
Partitioning +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
} 
} ˝
~D:\Real-Estate\RealEstate.Application\Features\Partitionings\Commands\UpdatePartitioning\UpdatePartitioningCommandValidator.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Partitionings* 7
.7 8
Commands8 @
.@ A
UpdatePartitioningA S
{ 
public 
class .
"UpdatePartitioningCommandValidator 0
:1 2
AbstractValidator3 D
<D E%
UpdatePartitioningCommandE ^
>^ _
{ 
public .
"UpdatePartitioningCommandValidator	 +
(+ ,
), -
{ 
RuleFor		 

(		
 
p		 
=>		 
p		 
.		 
Id		 
)		 
.

 
NotEmpty

 
(

 
)

 
.

 
WithMessage

 
(

 
$str

 9
)

9 :
. 
NotNull 
( 
) 
. 
NotEqual 
( 
Guid 
. 
Empty 
) 
; 
RuleFor 

(
 
p 
=> 
p 
. 
Type 
) 
. 
NotEmpty 
( 
) 
. 
WithMessage 
( 
$str 9
)9 :
. 
NotNull 
( 
) 
. 
MaximumLength 
( 
$num 
) 
. 
WithMessage 
( 
$str A
)A B
;B C
} 
} 
} î
qD:\Real-Estate\RealEstate.Application\Features\Partitionings\Commands\UpdatePartitioning\UpdatePartitioningDto.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Partitionings* 7
.7 8
Commands8 @
.@ A
UpdatePartitioningA S
{ 
public 
class !
UpdatePartitioningDto #
{ 
public 
string	 
? 
Type 
{ 
get 
; 
set  
;  !
}" #
} 
} ≈
gD:\Real-Estate\RealEstate.Application\Features\Partitionings\Queries\GetAll\GetAllPartitioningsQuery.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Partitionings* 7
.7 8
Queries8 ?
.? @
GetAll@ F
{ 
public 

class $
GetAllPartitioningsQuery )
:* +
IRequest, 4
<4 5'
GetAllPartitioningsResponse5 P
>P Q
{ 
} 
} Ÿ
nD:\Real-Estate\RealEstate.Application\Features\Partitionings\Queries\GetAll\GetAllPartitioningsQueryHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Partitionings* 7
.7 8
Queries8 ?
.? @
GetAll@ F
{ 
public 

class +
GetAllPartitioningsQueryHandler 0
:1 2
IRequestHandler3 B
<B C$
GetAllPartitioningsQueryC [
,[ \'
GetAllPartitioningsResponse] x
>x y
{ 
private 
readonly #
IPartitioningRepository 0

repository1 ;
;; <
public		 +
GetAllPartitioningsQueryHandler		 .
(		. /#
IPartitioningRepository		/ F

repository		G Q
)		Q R
{

 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< '
GetAllPartitioningsResponse 5
>5 6
Handle7 =
(= >$
GetAllPartitioningsQuery> V
requestW ^
,^ _
CancellationToken` q
cancellationToken	r É
)
É Ñ
{ 	'
GetAllPartitioningsResponse '
response( 0
=1 2
new3 6
(6 7
)7 8
;8 9
var 
result 
= 
await 

repository )
.) *
GetAllAsync* 5
(5 6
)6 7
;7 8
if 
( 
result 
. 
	IsSuccess 
)  
{ 
response 
. 
Partitionings &
=' (
result) /
./ 0
Value0 5
.5 6
Select6 <
(< =
partitioning= I
=>J L
newM P
PartitioningsDtoQ a
{ 
Id 
= 
partitioning %
.% &
Id& (
,( )
Type 
= 
partitioning '
.' (
Type( ,
} 
) 
. 
ToList 
( 
) 
; 
} 
return 
response 
; 
} 	
} 
} ∫
jD:\Real-Estate\RealEstate.Application\Features\Partitionings\Queries\GetAll\GetAllPartitioningsResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Partitionings* 7
.7 8
Queries8 ?
.? @
GetAll@ F
{ 
public 

class '
GetAllPartitioningsResponse ,
{ 
public 
List 
< 
PartitioningsDto $
>$ %
Partitionings& 3
{4 5
get6 9
;9 :
set; >
;> ?
}@ A
} 
} Ó
hD:\Real-Estate\RealEstate.Application\Features\Partitionings\Queries\GetById\GetByIdPartitioningQuery.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Partitionings* 7
.7 8
Queries8 ?
.? @
GetById@ G
{ 
public 

record $
GetByIdPartitioningQuery *
(* +
Guid+ /
Id0 2
)2 3
:4 5
IRequest6 >
<> ?
PartitioningsDto? O
>O P
;P Q
} ÷
oD:\Real-Estate\RealEstate.Application\Features\Partitionings\Queries\GetById\GetByIdPartitioningQueryHandler.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Partitionings* 7
.7 8
Queries8 ?
.? @
GetById@ G
{ 
public 

class +
GetByIdPartitioningQueryHandler 0
:1 2
IRequestHandler3 B
<B C$
GetByIdPartitioningQueryC [
,[ \
PartitioningsDto] m
>m n
{ 
private 
readonly #
IPartitioningRepository 0

repository1 ;
;; <
public +
GetByIdPartitioningQueryHandler .
(. /#
IPartitioningRepository/ F

repositoryG Q
)Q R
{		 	
this

 
.

 

repository

 
=

 

repository

 (
;

( )
} 	
public 
async 
Task 
< 
PartitioningsDto *
>* +
Handle, 2
(2 3$
GetByIdPartitioningQuery3 K
requestL S
,S T
CancellationTokenU f
cancellationTokeng x
)x y
{ 	
var 
partitioning 
= 
await $

repository% /
./ 0
FindByIdAsync0 =
(= >
request> E
.E F
IdF H
)H I
;I J
if 
( 
partitioning 
. 
	IsSuccess %
)% &
{ 
return 
new 
PartitioningsDto +
{ 
Id 
= 
partitioning %
.% &
Value& +
.+ ,
Id, .
,. /
Type 
= 
partitioning '
.' (
Value( -
.- .
Type. 2
} 
; 
} 
return 
new 
PartitioningsDto '
(' (
)( )
;) *
} 	
} 
} ç
XD:\Real-Estate\RealEstate.Application\Features\Partitionings\Queries\PartitioningsDto.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Features! )
.) *
Partitionings* 7
.7 8
Queries8 ?
{ 
public 

class 
PartitioningsDto !
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
string 
Type 
{ 
get  
;  !
set" %
;% &
}' (
=) *
default+ 2
!2 3
;3 4
} 
} ˛
CD:\Real-Estate\RealEstate.Application\Models\Identity\LoginModel.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Models! '
.' (
Identity( 0
{ 
public 
class 

LoginModel 
{ 
[ 
EmailAddress 
] 
[ 
Required 
( 
ErrorMessage 
= 
$str .
). /
]/ 0
public		 
string			 
?		 
Email		 
{		 
get		 
;		 
set		 !
;		! "
}		# $
[ 
Required 
( 
ErrorMessage 
= 
$str 1
)1 2
]2 3
public 
string	 
? 
Password 
{ 
get 
;  
set! $
;$ %
}& '
} 
} å
JD:\Real-Estate\RealEstate.Application\Models\Identity\RegistrationModel.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Models! '
.' (
Identity( 0
{ 
public 

class 
RegistrationModel "
{ 
public 
string 
? 
Id 
{ 
get 
;  
set! $
;$ %
}& '
[		 	
Required			 
(		 
ErrorMessage		 
=		  
$str		! 8
)		8 9
]		9 :
public

 
string

 
?

 
Username

 
{

  !
get

" %
;

% &
set

' *
;

* +
}

, -
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 3
)3 4
]4 5
public 
string 
? 
Name 
{ 
get !
;! "
set# &
;& '
}( )
[ 	
EmailAddress	 
] 
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 4
)4 5
]5 6
public 
string 
? 
Email 
{ 
get "
;" #
set$ '
;' (
}) *
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 7
)7 8
]8 9
public 
string 
? 
Password 
{  !
get" %
;% &
set' *
;* +
}, -
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 4
)4 5
]5 6
public 
string 
? 
PhoneNumber "
{# $
get% (
;( )
set* -
;- .
}/ 0
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 3
)3 4
]4 5
public 
string 
? 
Role 
{ 
get !
;! "
set# &
;& '
}( )
} 
} û
KD:\Real-Estate\RealEstate.Application\Models\Identity\ResetPasswordModel.cs
	namespace 	

RealEstate
 
. 
Identity 
. 
Models $
{ 
public 

class 
ResetPasswordModel #
{ 
[ 	
Required	 
] 
public 
string 
Password 
{  
get! $
;$ %
set& )
;) *
}+ ,
=- .
null/ 3
!3 4
;4 5
[

 	
Compare

	 
(

 
$str

 
,

 
ErrorMessage

 )
=

* +
$str

, a
)

a b
]

b c
public 
string 
? 
ConfirmPassword &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
=5 6
null7 ;
!; <
;< =
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
=* +
null, 0
!0 1
;1 2
public 
string 
Token 
{ 
get !
;! "
set# &
;& '
}( )
=* +
null, 0
!0 1
;1 2
} 
} ©
GD:\Real-Estate\RealEstate.Application\Persistence\IAddressRepository.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Persistence! ,
{ 
public 

	interface 
IAddressRepository '
:( )
IAsyncRepository* :
<: ;
Address; B
>B C
{ 
} 
}		 Ø
ID:\Real-Estate\RealEstate.Application\Persistence\IApartmentRepository.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Persistence! ,
{ 
public 

	interface  
IApartmentRepository )
:* +
IAsyncRepository, <
<< =
	Apartment= F
>F G
{ 
}		 
}

 ◊
ED:\Real-Estate\RealEstate.Application\Persistence\IAsyncRepository.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
	Contracts! *
{ 
public 

	interface 
IAsyncRepository %
<% &
T& '
>' (
where) .
T/ 0
:1 2
class3 8
{ 
Task 
< 
Result 
< 
T 
> 
> 
UpdateAsync #
(# $
T$ %
entity& ,
), -
;- .
Task 
< 
Result 
< 
T 
> 
> 
FindByIdAsync %
(% &
Guid& *
id+ -
)- .
;. /
Task		 
<		 
Result		 
<		 
T		 
>		 
>		 
AddAsync		  
(		  !
T		! "
entity		# )
)		) *
;		* +
Task

 
<

 
Result

 
<

 
T

 
>

 
>

 
DeleteAsync

 #
(

# $
Guid

$ (
id

) +
)

+ ,
;

, -
Task 
< 
Result 
< 
IReadOnlyList !
<! "
T" #
># $
>$ %
>% & 
GetPagedReponseAsync' ;
(; <
int< ?
page@ D
,D E
intF I
sizeJ N
)N O
;O P
Task 
< 
Result 
< 
IReadOnlyList !
<! "
T" #
># $
>$ %
>% &
GetAllAsync' 2
(2 3
)3 4
;4 5
} 
} ¨
HD:\Real-Estate\RealEstate.Application\Persistence\IBasePostRepository.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Persistence! ,
{ 
public 

	interface 
IBasePostRepository (
:) *
IAsyncRepository+ ;
<; <
BasePost< D
>D E
{ 
} 
}		 ¶
FD:\Real-Estate\RealEstate.Application\Persistence\IClientRepository.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Persistence! ,
{ 
public 

	interface 
IClientRepository &
:' (
IAsyncRepository) 9
<9 :
Client: @
>@ A
{ 
} 
}		  
RD:\Real-Estate\RealEstate.Application\Persistence\ICommercialCategoryRepository.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Persistence! ,
{ 
public 

	interface )
ICommercialCategoryRepository 2
:3 4
IAsyncRepository5 E
<E F
CommercialCategoryF X
>X Y
{ 
} 
}		 ≤
JD:\Real-Estate\RealEstate.Application\Persistence\ICommercialRepository.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Persistence! ,
{ 
public 

	interface !
ICommercialRepository *
:+ ,
IAsyncRepository- =
<= >

Commercial> H
>H I
{ 
} 
}		  
RD:\Real-Estate\RealEstate.Application\Persistence\ICommercialSpecificRepository.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Persistence! ,
{ 
public 

	interface )
ICommercialSpecificRepository 2
:3 4
IAsyncRepository5 E
<E F
CommercialSpecificF X
>X Y
{ 
} 
}		 ∏
LD:\Real-Estate\RealEstate.Application\Persistence\IHotelPensionRepository.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Persistence! ,
{ 
public 

	interface #
IHotelPensionRepository ,
:- .
IAsyncRepository/ ?
<? @
HotelPension@ L
>L M
{ 
} 
}		 £
ED:\Real-Estate\RealEstate.Application\Persistence\IHouseRepository.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Persistence! ,
{ 
public 

	interface 
IHouseRepository %
:& '
IAsyncRepository( 8
<8 9
House9 >
>> ?
{ 
} 
}		 Ø
ID:\Real-Estate\RealEstate.Application\Persistence\IHouseTypeRepository.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Persistence! ,
{ 
public 

	interface  
IHouseTypeRepository )
:* +
IAsyncRepository, <
<< =
	HouseType= F
>F G
{ 
} 
}		 «
QD:\Real-Estate\RealEstate.Application\Persistence\ILotClassificationRepository.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Persistence! ,
{ 
public 

	interface (
ILotClassificationRepository 1
:2 3
IAsyncRepository4 D
<D E
LotClassificationE V
>V W
{ 
} 
}		 ù
CD:\Real-Estate\RealEstate.Application\Persistence\ILotRepository.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Persistence! ,
{ 
public 

	interface 
ILotRepository #
:$ %
IAsyncRepository& 6
<6 7
Lot7 :
>: ;
{ 
} 
}		 ∏
LD:\Real-Estate\RealEstate.Application\Persistence\IPartitioningRepository.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
Persistence! ,
{ 
public 

	interface #
IPartitioningRepository ,
:- .
IAsyncRepository/ ?
<? @
Partitioning@ L
>L M
{ 
}		 
}

 ∆

?D:\Real-Estate\RealEstate.Application\Responses\BaseResponse.cs
	namespace 	

RealEstate
 
. 
Application  
.  !
	Responses! *
{ 
public 

class 
BaseResponse 
{ 
public 
BaseResponse 
( 
) 
=>  
Success! (
=) *
true+ /
;/ 0
public 
BaseResponse 
( 
string "
message# *
,* +
bool, 0
success1 8
)8 9
{ 	
Success		 
=		 
success		 
;		 
Message

 
=

 
message

 
;

 
} 	
public 
bool 
Success 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
Message 
{ 
get  #
;# $
set% (
;( )
}* +
public 
List 
< 
string 
> 
? 
ValidationErrors -
{. /
get0 3
;3 4
set5 8
;8 9
}: ;
} 
} 