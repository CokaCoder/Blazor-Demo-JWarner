<h3>Welcome, and thanks for looking at my demo Blazor app!</h3>
<h3> * To run the demo, please make "ProxyServer" your startup project in Visual Studio and hit F5.</h3>
<br />
<p><b>Extract from home component.</b></p>
<p class="suggestion">Using the menu on the left, you can search for details about a UK vehicle.</p>
<p>The "Acceptance Criteria" for this demo would be.. </p>
<ul>
    <li>As a <b>user running the application</b></li>
    <li>I want to <b>view a vehicle MOT Expiry date if I submit a registration number (e.g. XX10ABC)</b></li>
    <li>So that <b>I know when to renew the MOT for this vehicle.</b></li>
</ul>
<p>This solution features a Blazor Single Page Application, which calls a Proxy API to relay a request to the publicly available .GOV uk API for vehicle queries. I decided to build the app using Blazor Web Assembly. However I later discovered this caused some issues with CORS. The vehicle\mot API has strict CORS rules, and won't allow a request from a Blazor WASM app running in Chrome. I decided to fix this for the demo, by creating a "proxy server" to relay my request and avoid the issue. The alternative was to start over again in Blazor Server or use Firefox only, neither of which I felt were good options. I also thought it would allow me to demonstrate some back-end knowledge.</p>
<p>In order to make the application easy to run, the Blazor SPA is hosted on the API server (self hosted.) I did this so that you don't need to run two separate applications, although in the real world they most likely would be. This is also why you will see that the Entities are doubled up at the moment. I try to follow the "Clean Architecture" pattern, and prefer to have applications as loosley coupled as possible. Normally I would have a set of "Entities" on the backend to interact with a database, which would be mapped to an internal object. I would then map the internal object to a DTO before returning it as Json to the client.</p>
<p>Here is a list of things I want to add to the project when I have more time.</p>
<p> - Unit tests for the API endpoint and service.</p>
<p> - Front end testing using b-unit.</p>
<p> - Authentication. Securing the Proxy Server.</p>
<p> - Local Caching for api results. Especially if getting multiple vehicles.</p>
<p> - Move sensitive information like api key's, to Azure secure vault/user secrets.</p>
<p> - Add more logging. I have used Serilog in the past.</p>
<p> - Finish off Error Boundary in MOT History component, to handle MOT's that are missing property values.</p>
<p> - Improvement of some logic. I put this together in a rush, but it would be nice to optimize some of the code.</p>
