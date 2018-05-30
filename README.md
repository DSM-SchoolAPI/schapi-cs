# Schapi-CS

Schapi CS는 Schapi의 C# 버전으로  
C# 기반의 급식, 학사일정 파싱 라이브러리입니다.  

## 1. 설치  

schapi-cs 는 Visual Studio의 Nuget Console 에 명령어를 입력하여    
프로젝트에 다음과 같이 설치할 수 있습니다.

```
Install-Package Schapi -Version 1.1.2
```

## 2. 예제

다음은 대덕소프트웨어마이스터고등학교 (G100000170) 의 5월 23일자 점심  
식단표를 불러와 출력하는 예제입니다.

```
var api = new SchoolAPI
(
    Kind.HIGH, 
    Region.DAEJEON, 
    "G100000170"
);

foreach (var menu in api.GetMonthlyMenus(2018, 5)[23].Lunch)
{
    Console.WriteLine(menu);
}
```

## 3. 1.0.0 과 1.1.2

Schapi 1.0.0 은 구조적으로 기존의 Schapi 에 비해 아쉬운 점이 많으니  
1.1.2 버전을 설치해주세요 ㅇㅁㅇ
