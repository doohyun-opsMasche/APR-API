# 프로젝트 시 공유사항
1. branch 생성 : PJT_이니셜_채번
2. push 방식 : [PJT_이니셜_채번] "간략한 push 사유"
3. push 전 local branch 최신화

# .net core 주요 CLI 정리
<h2>.net core</h2>
<p> 프로젝트 build </p>
<pre>
    <code> dotnet build</code>    
</pre>
<p> 프로젝트 package 설치 </p>
<pre>
    <code> dotnet restore</code>    
</pre>
<p> 프로젝트 실행 </p>
<pre>
    <code> dotnet run</code>
    <code> dotnet run --launch-profile 'IIS Express - ngkang'</code>
</pre>


# .net core entity framework 주요 CLI 정리
<h2>EF Core</h2>
<p> EF 기반의 Migrations 정보 생성 </p>
<pre>
    <code> dotnet ef migrations add  { name }</code>
</pre>

<p> EF 기반의 Migrations 정보 생성 by Context </p>
<pre>
    <code> dotnet ef migrations add  { name } --context { ContextName } </code>
</pre>

<p> 생성된 Migrations 정보 삭제 </p>
<pre>
    <code> dotnet ef migrations remove </code>
</pre>

<p> 생성된 Migrations 정보 삭제 by Context </p>
<pre>
    <code> dotnet ef migrations remove --context { ContextName } </code>
</pre>

<p> migrations 된 정보를 기준으로 DB </p>
<pre>
    <code> dotnet ef database update </code>
</pre>

<p> migrations 된 정보를 기준으로 DB by Context </p>
<pre>
    <code> dotnet ef database update --context { ContextName } </code>
</pre>

<p> DB를 삭제, database 자체를 삭제 </p>
<pre>
    <code> dotnet ef database drop </code>
</pre>

<p> DB를 삭제, database 자체를 삭제 by Context </p>
<pre>
    <code> dotnet ef database drop --context { ContextName } </code>
</pre>

dotnet run                          // 프로젝트 실행
dotnet run --launch-profile 'IIS Express - ngkang'  // IIS Express - ngkang 로 된 Profile 실행

# 환경 설정을 변경하는 방법
1. cli 명령으로 변경
set ASPNETCORE_ENVIRONMENT=ngkang

2. .vscode\launch.json 내 정보 수정
 "configurations": [
        {
             "env": {
                "ASPNETCORE_ENVIRONMENT": "ngkang"
            }
        }
 ]

 위 정보를 설정해야 dotnet ef 명령 실행시 해당 appsettings.ngkang.json 정보를 기준으로 database를 저장 합니다.    
