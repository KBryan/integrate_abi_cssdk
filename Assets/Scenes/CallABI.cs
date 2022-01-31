using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallABI : MonoBehaviour
{
    // UI Element for value
    public Text setValue;
    // set chain
    string chain = "ethereum";
    // set network
    string network = "rinkeby";
    // smart contract address
    private string contract = "0xBb35a2aF40aBF09A03B3A109c42F529e23E2Ea59";
    private readonly string abi = "[{\"inputs\":[],\"name\":\"retrieve\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"num\",\"type\":\"uint256\"}],\"name\":\"store\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"}]";

    async public void AddValue()
    {
        // smart contract method to call
        string method = "store";
        string args = "[\"10\"]";
        // value in wei
        string value = "0";
        // gas limit
        string gasLimit = "";
        // gas price optional
        string gasPrice = "";

        // connect to users wallet
        try
        {
            string response = await Web3GL.SendContract(method, abi, contract, args, value, gasLimit, gasPrice);
            Debug.Log(response);
        } catch(Exception e)
        {
            Debug.LogException(e, this);
        }
    }
    async public void RetrieveValue()
    {
        // string method
        string method = "retrieve";
        string args = "[]";
        // call method
        try
        {
            string response = await EVM.Call(chain, network, contract, abi, method, args);
            setValue.text = response;
            Debug.Log(response);
        }
        catch(Exception e)
        {
            Debug.LogException(e, this);
        }
    }
}
