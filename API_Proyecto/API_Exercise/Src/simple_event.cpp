/*==============================================================================
Simple Event Example
Copyright (c), Firelight Technologies Pty, Ltd 2012-2022.

This example demonstrates the various ways of playing an event.

#### Explosion Event ####
This event is played as a one-shot and released immediately after it has been
created.

#### Looping Ambience Event ####
A single instance is started or stopped based on user input.

#### Cancel Event ####
This instance is started and if already playing, restarted.

For information on using FMOD example code in your own programs, visit
https://www.fmod.com/legal
==============================================================================*/
#include "fmod_studio.hpp"
#include "fmod.hpp"
#include "common.h"

int FMOD_Main()
{
    void *extraDriverData = NULL;
    Common_Init(&extraDriverData);

    FMOD::Studio::System* system = NULL;
    ERRCHECK( FMOD::Studio::System::create(&system) );

    // The example Studio project is authored for 5.1 sound, so set up the system output mode to match
    FMOD::System* coreSystem = NULL;
    ERRCHECK( system->getCoreSystem(&coreSystem) );
    ERRCHECK( coreSystem->setSoftwareFormat(0, FMOD_SPEAKERMODE_5POINT1, 0) );

    ERRCHECK( system->initialize(1024, FMOD_STUDIO_INIT_NORMAL, FMOD_INIT_NORMAL, extraDriverData) );
    
    FMOD::Studio::Bank* masterBank = NULL;
    ERRCHECK( system->loadBankFile(Common_MediaPath("StepsBank.bank"), FMOD_STUDIO_LOAD_BANK_NORMAL, &masterBank) );


    FMOD::Studio::Bank* stringsBank = NULL;
    ERRCHECK( system->loadBankFile(Common_MediaPath("StepsBank.strings.bank"), FMOD_STUDIO_LOAD_BANK_NORMAL, &stringsBank) );
    
 //   FMOD::Studio::Bank* sfxBank = NULL;
 //   ERRCHECK( system->loadBankFile(Common_MediaPath("SFX.bank"), FMOD_STUDIO_LOAD_BANK_NORMAL, &sfxBank) );

 //   //Steps ================================================================
	//FMOD::Studio::Bank* StepsBank = NULL;
	//ERRCHECK(system->loadBankFile(Common_MediaPath("StepsBank.bank"), FMOD_STUDIO_LOAD_BANK_NORMAL, &StepsBank));

	//FMOD::Studio::Bank* StepsStringsBank = NULL;
	//ERRCHECK(system->loadBankFile(Common_MediaPath("StepsBank.strings.bank"), FMOD_STUDIO_LOAD_BANK_NORMAL, &StepsStringsBank));

	// Get the Single Explosion event

	float incrementRe = 0.20f;
	float incrementVel = 0.34f;
	float velocity = 0.0f + incrementVel;
	float recinto = 0.0f;

	FMOD::Studio::EventDescription* stepsDescription = NULL;
	ERRCHECK(system->getEvent("event:/Steps", &stepsDescription));

	FMOD::Studio::EventInstance* stepsInstance = NULL;
    ERRCHECK(stepsDescription->createInstance(&stepsInstance) );

    ERRCHECK(stepsInstance->setParameterByName("Recinto", recinto));
    ERRCHECK(stepsInstance->setParameterByName("velocidad", velocity));
	// Start loading explosion sample data and keep it in memory
	//ERRCHECK(stepsDescription->loadSampleData());


    //======================================================================

    // Get the Looping Ambience event
    //FMOD::Studio::EventDescription* loopingAmbienceDescription = NULL;
    //ERRCHECK( system->getEvent("event:/Ambience/Country", &loopingAmbienceDescription) );
    
    //FMOD::Studio::EventInstance* loopingAmbienceInstance = NULL;
    //ERRCHECK( loopingAmbienceDescription->createInstance(&loopingAmbienceInstance) );
    
    // Get the 4 Second Surge event
    //FMOD::Studio::EventDescription* cancelDescription = NULL;
    //ERRCHECK( system->getEvent("event:/UI/Cancel", &cancelDescription) );
    
    //FMOD::Studio::EventInstance* cancelInstance = NULL;
    //ERRCHECK( cancelDescription->createInstance(&cancelInstance) );
    
    // Get the Single Explosion event
    //FMOD::Studio::EventDescription* explosionDescription = NULL;
    //ERRCHECK( system->getEvent("event:/Weapons/Explosion", &explosionDescription) );

    // Start loading explosion sample data and keep it in memory
    //ERRCHECK( explosionDescription->loadSampleData() );

    do
    {
        Common_Update();
        
        //if (Common_BtnPress(BTN_ACTION1))
        //{
        //    // One-shot event
        //    FMOD::Studio::EventInstance* eventInstance = NULL;
        //    ERRCHECK( explosionDescription->createInstance(&eventInstance) );

        //    ERRCHECK( eventInstance->start() );

        //    // Release will clean up the instance when it completes
        //    ERRCHECK( eventInstance->release() );
        //}
    
        //if (Common_BtnPress(BTN_ACTION2))
        //{
        //    ERRCHECK( loopingAmbienceInstance->start() );
        //}

        //if (Common_BtnPress(BTN_ACTION3))
        //{
        //    ERRCHECK( loopingAmbienceInstance->stop(FMOD_STUDIO_STOP_IMMEDIATE) );
        //}

        //if (Common_BtnPress(BTN_ACTION4))
        //{
        //    // Calling start on an instance will cause it to restart if it's already playing
        //    ERRCHECK( cancelInstance->start() );
        //}

		if (Common_BtnPress(BTN_ACTION5))
		{
			// One-shot event
			//FMOD::Studio::EventInstance* eventInstance = NULL;
			//ERRCHECK(stepsDescription->createInstance(&eventInstance));

			ERRCHECK(stepsInstance->start());

			// Release will clean up the instance when it completes
			//ERRCHECK(stepsInstance->release());
		}

		if (Common_BtnPress(BTN_UP))
		{
            recinto += incrementRe;
            if (recinto >= 1.0f) recinto = 1.0f;
			ERRCHECK(stepsInstance->setParameterByName("Recinto", recinto));

			
			// One-shot event
			//FMOD::Studio::EventInstance* eventInstance = NULL;
			//ERRCHECK(stepsDescription->createInstance(&eventInstance));

			//ERRCHECK(eventInstance->start());

			//// Release will clean up the instance when it completes
			//ERRCHECK(eventInstance->release());
		}

		if (Common_BtnPress(BTN_DOWN))
		{
            recinto -= incrementRe;
            if (recinto <= 0.0f) recinto = 0.0f;
            ERRCHECK(stepsInstance->setParameterByName("Recinto", recinto));

			//// One-shot event
			//FMOD::Studio::EventInstance* eventInstance = NULL;
			//ERRCHECK(stepsDescription->createInstance(&eventInstance));

			//ERRCHECK(eventInstance->start());

			//// Release will clean up the instance when it completes
			//ERRCHECK(eventInstance->release());
		}

		if (Common_BtnPress(BTN_LEFT))
		{

            velocity -= incrementVel;
            if (velocity <= 0.0f) velocity = 0.0f;
            ERRCHECK(stepsInstance->setParameterByName("velocidad", velocity));
			//// One-shot event
			//FMOD::Studio::EventInstance* eventInstance = NULL;
			//ERRCHECK(stepsDescription->createInstance(&eventInstance));

			//ERRCHECK(eventInstance->start());

			//// Release will clean up the instance when it completes
			//ERRCHECK(eventInstance->release());
		}

		if (Common_BtnPress(BTN_RIGHT))
		{
			velocity += incrementVel;
            if (velocity >= 1.0f) velocity = 1.0f;
            ERRCHECK(stepsInstance->setParameterByName("velocidad", velocity));
			//// One-shot event
			//FMOD::Studio::EventInstance* eventInstance = NULL;
			//ERRCHECK(stepsDescription->createInstance(&eventInstance));

			//ERRCHECK(eventInstance->start());

			//// Release will clean up the instance when it completes
			//ERRCHECK(eventInstance->release());
		}

        ERRCHECK( system->update() );

        Common_Draw("==================================================");
        Common_Draw("Simple Event Example.");
        Common_Draw("Copyright (c) Firelight Technologies 2012-2022.");
        Common_Draw("==================================================");
        Common_Draw("");
        Common_Draw("Press %s to fire and forget the explosion", Common_BtnStr(BTN_ACTION1));
        Common_Draw("Press %s to start the looping ambience", Common_BtnStr(BTN_ACTION2));
        Common_Draw("Press %s to stop the looping ambience", Common_BtnStr(BTN_ACTION3));
        Common_Draw("Press %s to start/restart the cancel sound", Common_BtnStr(BTN_ACTION4));
        Common_Draw("Press %s to start steps sound", Common_BtnStr(BTN_ACTION5));
        Common_Draw("Press %s and %s to increse o decrease reverb", Common_BtnStr(BTN_UP), Common_BtnStr(BTN_DOWN));
        Common_Draw("Reverb value: %f", recinto);
        Common_Draw("Press %s and %s to increse o decrease velocity", Common_BtnStr(BTN_LEFT), Common_BtnStr(BTN_RIGHT));
        Common_Draw("Velocity value: %f", velocity);
        Common_Draw("Press %s to quit", Common_BtnStr(BTN_QUIT));

        Common_Sleep(50);
    } while (!Common_BtnPress(BTN_QUIT));
    
    //ERRCHECK( sfxBank->unload() );
    ERRCHECK( stringsBank->unload() );
    ERRCHECK( masterBank->unload() );

    ERRCHECK( system->release() );

    Common_Close();

    return 0;
}
