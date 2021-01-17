To run the project, below are the instructions -
1. Clean and build the solution
2. ChromeDriver.exe should be present in  TFLWebsiteJourneyPlanner\TFLWebsiteJourneyPlannerTest\bin\Debug
3. Go to test explorer, it should load all the 5 tests present in the feature file   TFLWebsiteJourneyPlanner\TFLWebsiteJourneyPlannerTest\FeaturesVerifyAllPossibleScenariosOnTFLHomePage.feature
4. To run any test out of these , right click and run.
5. If you face any issues while running the test, please re-install NUnit3TestAdapter(Latest version) package.
6. Before executing any scenario , [BeforeScenario] will run which is present in TFLWebsiteJourneyPlanner\TFLWebsiteJourneyPlannerFramework\Hooks.cs
7. After executing any scenario, [AfterScenario] will run which is present in TFLWebsiteJourneyPlanner\TFLWebsiteJourneyPlannerFramework\Hooks.cs. It will also handle the exceptions if any are present.


Project Architecture:
1. TFLWebsiteJourneyPlanner\TFLWebsiteJourneyPlannerFramework -- project has all the common features like instantiating the WebPage, picking the driver & URL from app.config and passing the parameter in "WebDrivers.cs" and "Hooks.cs" respectively. Also all the common methods used in selenium like "wait and click for an web element", clearing the text and sending keys in text box , scrolling down and up on the webpage, returning the list of the web elements are present in this project.
 
2. TFLWebsiteJourneyPlanner\TFLWebsiteJourneyPlannerDomain --project has all the details of the different webpages pages. On any page.cs, it will give all the methods performed on that page. This project has reference of TFLWebsiteJourneyPlannerFramework projects.

3. TFLWebsiteJourneyPlanner\TFLWebsiteJourneyPlannerSteps -- project has all the step definition binding for any feature file. This project has reference of TFLWebsiteJourneyPlannerDomain and TFLWebsiteJourneyPlannerFramework projects.

4. TFLWebsiteJourneyPlanner\TFLWebsiteJourneyPlannerTest -- project has all the feature files having scenarios need to be executed. It should have ChromeDriver.exe in  TFLWebsiteJourneyPlanner\TFLWebsiteJourneyPlannerTest\bin\Debug. Values present in app.config of this project will be passed for picking the driver & URL. This project has reference of TFLWebsiteJourneyPlannerSteps, TFLWebsiteJourneyPlannerDomain and TFLWebsiteJourneyPlannerFramework projects 

Execution will be from TFLWebsiteJourneyPlannerTest >>TFLWebsiteJourneyPlannerSteps>>TFLWebsiteJourneyPlannerDomain>>TFLWebsiteJourneyPlannerFramework for any scenario, though [BeforeScenario] will run first which is present in TFLWebsiteJourneyPlanner\TFLWebsiteJourneyPlannerFramework\Hooks.cs preceding any scenario's execution. [AfterScenario] will run which is present in TFLWebsiteJourneyPlanner\TFLWebsiteJourneyPlannerFramework\Hooks.cs following any scenario's execution.   

