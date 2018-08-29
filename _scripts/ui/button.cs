/*
 ************************************************
 * Name: button.cs
 * Updated: 11/26/2017
 * Author: Sean Francis
 * Description: Variables and Functions that run
 *              when a UI button is Pressed.
 ************************************************
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class button : MonoBehaviour {

    [Header("UI Buttons")]
    public GameObject vContinue;
    public GameObject vMainMenu;
    public GameObject mContinue;
    public GameObject mMainMenu;
    public GameObject gContinue;
    public GameObject gMainMenu;
    /*public Button pauseContinue;
    public Button mainNewGame;
    public Button subPlay;
    public Button statReturn;
    public Button controlReturn;
    public Button creditReturn;
    public Button newGameSlot1;
    public Button loadGameSlot1;
    public Button newGameWarnConfirm;
    public Button loadGameWarnConfirm;*/

    [Header("UI Screens/Messages")]
    public GameObject pauseUI;
    public GameObject gameUI;
    public GameObject mainMenuUI;
    public GameObject creditsMenuUI;
    public GameObject loadMenuUI;
    public GameObject newGameUI;
    public GameObject subMenuUI;
    public GameObject statMenuUI;
    public GameObject switchLevelUI;
    public GameObject gameOverUI;
    public GameObject newGameWarning;
    public GameObject loadGameWarning;
    public GameObject victoryUI;
    public GameObject controlsMenuUI;
    
    [Header("Edittable Text")]
    public Text slot1Label;
    public Text slot2Label;
    public Text slot3Label;
    public Text newGameSlot1Label;
    public Text newGameSlot2Label;
    public Text newGameSlot3Label;
    
    void Start(){
        
        levelData.gameUI = this.gameUI;
        levelData.victoryUI = this.victoryUI;
        levelData.switchLevelUI = this.switchLevelUI;
        levelData.gameOverUI = this.gameOverUI;
        levelData.pauseUI = this.pauseUI;

        levelData.victoryContinue = vContinue;
        levelData.victoryMainMenu = vMainMenu;
        levelData.moveContinue = mContinue;
        levelData.moveMainMenu = mMainMenu;
        levelData.gOverContinue = gContinue;
        levelData.gOverMainMenu = gMainMenu;
        
    }
    
    public void playGame(){

        if (levelData.victoryUI != null)
        {

            levelData.victoryUI.SetActive(false);

        }

        if (levelData.gameOverUI != null)
        {

            levelData.gameOverUI.SetActive(false);

        }

        if (levelData.switchLevelUI != null)
        {

            levelData.switchLevelUI.SetActive(false);

        }

        dataRestore.restoreAllDef();
        SceneManager.LoadScene(Random.Range(2, SceneManager.sceneCountInBuildSettings - 1), LoadSceneMode.Single);
        
    }

	/*public void restartLevel(){
        
        string scene = SceneManager.GetActiveScene().name;
        
        savePrefs.save();
        
        player.restoreDefault();
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        
    }*/
    
    public void quitGame(){
        
        Application.Quit();
        
    }
    
    public void pause(){
        
        gameUI.SetActive(false);
        pauseUI.SetActive(true);
        Cursor.visible = true;

        Time.timeScale = 0.0f;

    }
    
    public void unPause(){

        if (gameUI != null)
        {

            gameUI.SetActive(true);

        }
        pauseUI.SetActive(false);
        Cursor.visible = false;
        
        Time.timeScale = 1.0f;
        
    }
    
    public void openSaveMenu(){
        
        /*saveLoadGame.loadAll();
        
        saveData slot1 = saveLoadGame.savedGames[0];
        saveData slot2 = saveLoadGame.savedGames[1];
        saveData slot3 = saveLoadGame.savedGames[2];
        
        mainMenuUI.SetActive(false);
        loadMenuUI.SetActive(true);
        
        if(slot1 == null){
        
            slot1Label.text = "No Data";
        
        } else {
            
            slot1Label.text = "Play Time:\n" + string.Format("{0:00} : {1:00}", slot1.timePlayed / 60, slot1.timePlayed % 60);
            
        }
        
        if(slot2 == null){
        
            slot2Label.text = "No Data";
        
        } else {
            
            slot2Label.text = "Play Time:\n" + string.Format("{0:00} : {1:00}", slot1.timePlayed / 60, slot1.timePlayed % 60);
            
        }
        
        if(slot3 == null){
        
            slot3Label.text = "No Data";
        
        } else {
            
            slot3Label.text = "Play Time:\n" + string.Format("{0:00} : {1:00}", slot1.timePlayed / 60, slot1.timePlayed % 60);
            
        }*/
        
        mainMenuUI.SetActive(false);
        loadMenuUI.SetActive(true);
        
        if(PlayerPrefs.GetInt("slot1Saved") == 0){
            
            slot1Label.text = "No Data";
            
        } else if(PlayerPrefs.GetInt("slot1Saved") == 1) {
            
            slot1Label.text = "Play Time:\n" + string.Format("{0:00} : {1:00}", (int)PlayerPrefs.GetFloat("slot1PlayTime") / 60, (int)PlayerPrefs.GetFloat("slot1PlayTime") % 60);
            
        }
        
        if(PlayerPrefs.GetInt("slot2Saved") == 0){
            
            slot2Label.text = "No Data";
            
        } else if(PlayerPrefs.GetInt("slot2Saved") == 1) {
            
            slot2Label.text = "Play Time:\n" + string.Format("{0:00} : {1:00}", (int)PlayerPrefs.GetFloat("slot2PlayTime") / 60, (int)PlayerPrefs.GetFloat("slot2PlayTime") % 60);
            
        }
        
        if(PlayerPrefs.GetInt("slot3Saved") == 0){
            
            slot3Label.text = "No Data";
            
        } else if(PlayerPrefs.GetInt("slot3Saved") == 1) {
            
            slot3Label.text = "Play Time:\n" + string.Format("{0:00} : {1:00}", (int)PlayerPrefs.GetFloat("slot3PlayTime") / 60, (int)PlayerPrefs.GetFloat("slot3PlayTime") % 60);
            
        }

        //loadGameSlot1.Select();
        
    }
    
    public void openNewGameMenu(){
        
       /* saveLoadGame.loadAll();
        
        saveData slot1 = saveLoadGame.savedGames[0];
        saveData slot2 = saveLoadGame.savedGames[1];
        saveData slot3 = saveLoadGame.savedGames[2];
        
        mainMenuUI.SetActive(false);
        newGameUI.SetActive(true);
        
        if(slot1 == null){
        
            slot1Label.text = "No Data";
        
        } else {
            
            slot1Label.text = "Play Time:\n" + string.Format("{0:00} : {1:00}", slot1.timePlayed / 60, slot1.timePlayed % 60);
            
        }
        
        if(slot2 == null){
        
            slot2Label.text = "No Data";
        
        } else {
            
            slot2Label.text = "Play Time:\n" + string.Format("{0:00} : {1:00}", slot1.timePlayed / 60, slot1.timePlayed % 60);
            
        }
        
        if(slot3 == null){
        
            slot3Label.text = "No Data";
        
        } else {
            
            slot3Label.text = "Play Time:\n" + string.Format("{0:00} : {1:00}", slot1.timePlayed / 60, slot1.timePlayed % 60);
            
        }*/
        
        mainMenuUI.SetActive(false);
        newGameUI.SetActive(true);
        
        if(PlayerPrefs.GetInt("slot1Saved") == 0){
            
            slot1Label.text = "No Data";
            
        } else if(PlayerPrefs.GetInt("slot1Saved") == 1) {
            
            newGameSlot1Label.text = "Play Time:\n" + string.Format("{0:00} : {1:00}", (int)PlayerPrefs.GetFloat("slot1PlayTime") / 60, (int)PlayerPrefs.GetFloat("slot1PlayTime") % 60);
            
        }
        
        if(PlayerPrefs.GetInt("slot2Saved") == 0){
            
            slot2Label.text = "No Data";
            
        } else if(PlayerPrefs.GetInt("slot2Saved") == 1) {
            
            newGameSlot2Label.text = "Play Time:\n" + string.Format("{0:00} : {1:00}", (int)PlayerPrefs.GetFloat("slot2PlayTime") / 60, (int)PlayerPrefs.GetFloat("slot2PlayTime") % 60);
            
        }
        
        if(PlayerPrefs.GetInt("slot3Saved") == 0){
            
            slot3Label.text = "No Data";
            
        } else if(PlayerPrefs.GetInt("slot3Saved") == 1) {
            
            newGameSlot3Label.text = "Play Time:\n" + string.Format("{0:00} : {1:00}", (int)PlayerPrefs.GetFloat("slot3PlayTime") / 60, (int)PlayerPrefs.GetFloat("slot3PlayTime") % 60);
            
        }

        //newGameSlot1.Select();

    }
    
    public void openCreditMenu(){
        
        mainMenuUI.SetActive(false);
        creditsMenuUI.SetActive(true);
        
    }
    
    public void openControlsMenu(){
        
        string name = SceneManager.GetActiveScene().name;
        
        if(name == "mainMenu"){
            
            mainMenuUI.SetActive(false);
            controlsMenuUI.SetActive(true);
        
        } else if(name == "subMenu"){
            
            subMenuUI.SetActive(false);
            controlsMenuUI.SetActive(true);
            
        }

        //controlReturn.Select();
    }
    
    public void returnToMain(bool toSave){
        
        string name = SceneManager.GetActiveScene().name;
        
        if(toSave){
            
            /*saveData.current.timePlayed += player.runTime;
            saveData.current.enemiesKilled += player.enemiesKilled;
            
            saveLoadGame.overwrite();*/
            
            savePrefs.save();
            
        }
        
        if(name == "mainMenu"){
            
            loadMenuUI.SetActive(false);
            newGameUI.SetActive(false);
            creditsMenuUI.SetActive(false);
            controlsMenuUI.SetActive(false);
            mainMenuUI.SetActive(true);
            
        } else {

            if (levelData.victoryUI != null)
            {

                levelData.victoryUI.SetActive(false);

            }

            if (levelData.gameOverUI != null)
            {

                levelData.gameOverUI.SetActive(false);

            }

            if (levelData.switchLevelUI != null)
            {

                levelData.switchLevelUI.SetActive(false);

            }

            dataRestore.restoreAllDef();
            SceneManager.LoadScene("mainMenu", LoadSceneMode.Single);
            
        }
        
    }
    
    public void returnToSub(bool toSave){
        
        string name = SceneManager.GetActiveScene().name;
        
        if(toSave){
            
            /*saveData.current.timePlayed += player.runTime;
            saveData.current.enemiesKilled += player.enemiesKilled;
            
            saveLoadGame.overwrite();*/
            
            savePrefs.save();
            
        }
        
        if(name == "subMenu"){
            
            statMenuUI.SetActive(false);
            controlsMenuUI.SetActive(false);
            subMenuUI.SetActive(true);
            
        } else {

            if (levelData.victoryUI != null)
            {

                levelData.victoryUI.SetActive(false);

            }

            if (levelData.gameOverUI != null)
            {

                levelData.gameOverUI.SetActive(false);

            }

            if (levelData.switchLevelUI != null)
            {

                levelData.switchLevelUI.SetActive(false);

            }

            dataRestore.restoreAllDef();
            SceneManager.LoadScene("subMenu", LoadSceneMode.Single);
            
        }
        
    }
    
    public void closeWarning(){
        
        newGameWarning.SetActive(false);
        loadGameWarning.SetActive(false);
        
    }
    
    public void confirmNewGameOverwrite(){
        
        /*saveLoadGame.delete();
        
        saveLoadGame.create();
        saveData.current = saveLoadGame.savedGames[saveLoadGame.saveSlot];*/
        
        savePrefs.reset();
        
        SceneManager.LoadScene("subMenu", LoadSceneMode.Single);
        
    }
    
    public void newSlotOne(){
        
        /*saveLoadGame.saveSlot = 0;
        
        if(saveLoadGame.savedGames[saveLoadGame.saveSlot] == null){
            
            newGameWarning.SetActive(false);
            
            saveLoadGame.create();
            saveData.current = saveLoadGame.savedGames[saveLoadGame.saveSlot];
        
        } else if(saveLoadGame.savedGames[saveLoadGame.saveSlot] != null) {
            
            newGameWarning.SetActive(true);
            
        }
        
        SceneManager.LoadScene("subMenu", LoadSceneMode.Single);*/
        
        savePrefs.prefSlot = 1;
        
        if(PlayerPrefs.GetInt("slot1Saved") == 1){
            
            newGameWarning.SetActive(true);
            
        } else if(PlayerPrefs.GetInt("slot1Saved") == 0){
            
            PlayerPrefs.SetInt("slot1Saved", 1);
            
            savePrefs.reset();
            
            SceneManager.LoadScene("subMenu", LoadSceneMode.Single);
            
        }
        
    }
    
    public void newSlotTwo(){
        
        /*saveLoadGame.saveSlot = 1;
        
        if(saveLoadGame.savedGames[saveLoadGame.saveSlot] == null){
            
            newGameWarning.SetActive(false);
            
            saveLoadGame.create();
            saveData.current = saveLoadGame.savedGames[saveLoadGame.saveSlot];
        
        } else if(saveLoadGame.savedGames[saveLoadGame.saveSlot] != null) {
            
            newGameWarning.SetActive(true);
            
        }
        
        SceneManager.LoadScene("subMenu", LoadSceneMode.Single);*/
        
        savePrefs.prefSlot = 2;
        
        if(PlayerPrefs.GetInt("slot2Saved") == 1){
            
            newGameWarning.SetActive(true);
            
        } else if(PlayerPrefs.GetInt("slot2Saved") == 0){
            
            PlayerPrefs.SetInt("slot2Saved", 1);
            
            savePrefs.reset();
            
            SceneManager.LoadScene("subMenu", LoadSceneMode.Single);
            
        }
        
    }
    
    public void newSlotThree(){
        
        /*saveLoadGame.saveSlot = 2;
        
        if(saveLoadGame.savedGames[saveLoadGame.saveSlot] == null){
            
            newGameWarning.SetActive(false);
            
            saveLoadGame.create();
            saveData.current = saveLoadGame.savedGames[saveLoadGame.saveSlot];
        
        } else if(saveLoadGame.savedGames[saveLoadGame.saveSlot] != null) {
            
            newGameWarning.SetActive(true);
            
        }
        
        SceneManager.LoadScene("subMenu", LoadSceneMode.Single);*/
        
        savePrefs.prefSlot = 3;
        
        if(PlayerPrefs.GetInt("slot3Saved") == 1){
            
            newGameWarning.SetActive(true);
            
        } else if(PlayerPrefs.GetInt("slot3Saved") == 0){
            
            PlayerPrefs.SetInt("slot3Saved", 1);
            
            savePrefs.reset();
            
            SceneManager.LoadScene("subMenu", LoadSceneMode.Single);
            
        }
        
    }
    
    public void loadSlotOne(){
        
        /*saveLoadGame.saveSlot = 0;
        
        if(saveLoadGame.savedGames[saveLoadGame.saveSlot] == null){
            
            loadGameWarning.SetActive(true);
            
        } else {
        
            saveLoadGame.load();
            saveData.current = saveLoadGame.savedGames[saveLoadGame.saveSlot];
            SceneManager.LoadScene("subMenu", LoadSceneMode.Single);
            
        }*/
        
        savePrefs.prefSlot = 1;
        
        if(PlayerPrefs.GetInt("slot1Saved") == 0){
            
            loadGameWarning.SetActive(true);
            
        } else {
            
            SceneManager.LoadScene("subMenu", LoadSceneMode.Single);
            
        }
        
    }
    
    public void loadSlotTwo(){
        
        /*saveLoadGame.saveSlot = 1;
        
        if(saveLoadGame.savedGames[saveLoadGame.saveSlot] == null){
            
            loadGameWarning.SetActive(true);
            
        } else {
        
            saveLoadGame.load();
            saveData.current = saveLoadGame.savedGames[saveLoadGame.saveSlot];
            SceneManager.LoadScene("subMenu", LoadSceneMode.Single);
            
        }*/
        
        savePrefs.prefSlot = 2;
        
        if(PlayerPrefs.GetInt("slot2Saved") == 0){
            
            loadGameWarning.SetActive(true);
            
        } else {
            
            SceneManager.LoadScene("subMenu", LoadSceneMode.Single);
            
        }
        
    }
    
    public void loadSlotThree(){
        
        /*saveLoadGame.saveSlot = 2;
        
        if(saveLoadGame.savedGames[saveLoadGame.saveSlot] == null){
            
            loadGameWarning.SetActive(true);
            
        } else {
        
            saveLoadGame.load();
            saveData.current = saveLoadGame.savedGames[saveLoadGame.saveSlot];
            SceneManager.LoadScene("subMenu", LoadSceneMode.Single);
            
        }*/
        
        savePrefs.prefSlot = 3;
        
        if(PlayerPrefs.GetInt("slot3Saved") == 0){
            
            loadGameWarning.SetActive(true);
            
        } else {
            
            SceneManager.LoadScene("subMenu", LoadSceneMode.Single);
            
        }
        
    }
    
    public void openStatMenu(){
        
        subMenuUI.SetActive(false);
        statMenuUI.SetActive(true);
        
    }

    public void openSurvey()
    {

        Application.OpenURL("https://goo.gl/forms/JI0KfpEI2tQ2FAJY2");

    }
    
    public void continueRun(){

        if (levelData.victoryUI != null)
        {

            levelData.victoryUI.SetActive(false);

        }

        if (levelData.gameOverUI != null)
        {

            levelData.gameOverUI.SetActive(false);

        }

        if (levelData.switchLevelUI != null)
        {

            levelData.switchLevelUI.SetActive(false);

        }

        dataRestore.restoreLevelDef();
        dataRestore.restoreTimerDef();
        player.restoreFacing();

        if (player.floorsCleared < player.maxClear - 1)
        {

            SceneManager.LoadScene(Random.Range(2, SceneManager.sceneCountInBuildSettings - 2), LoadSceneMode.Single);

        } else
        {

            SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1, LoadSceneMode.Single);

        }

    }
    
    public void restartRun(bool toSave){
        
        if(toSave){
            
            savePrefs.save();
            
        }

        if (levelData.victoryUI != null)
        {

            levelData.victoryUI.SetActive(false);

        }

        if (levelData.gameOverUI != null)
        {

            levelData.gameOverUI.SetActive(false);

        }

        if (levelData.switchLevelUI != null)
        {

            levelData.switchLevelUI.SetActive(false);

        }

        playGame();
        
    }

    public void changeFloor()
    {

        player.floorsCleared++;
        continueRun();

    }
    
}
