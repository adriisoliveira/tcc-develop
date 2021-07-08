import React from "react";
import {
  View,
  Image,
  Text,
  TextInput
} from "react-native";
import { Background } from "../../components/Background";
import { styles } from "./styles";
import Logo_Autem from "../../assets/logoAutem.png";
import {
  Button,
  ButtonCreateAc,
  ButtonEnter,
  ButtonGoogle,
  ButtonICloud,
  ButtonFacebook
} from "../../components/Button"
import { useNavigation } from "@react-navigation/native";

export function Login() {
  const navigation = useNavigation();

  function handleSignIn() {
    navigation.navigate('SignIn');
  }

  function handleRegister() {
    navigation.navigate('Register');
  }

  return (
    <Background>
      <View style={styles.container}>
        <View style={styles.createAccount}>
          <Text style={styles.text}>Criar Conta</Text>
          <ButtonCreateAc
            onPress={handleRegister}
          />
        </View>

        <View style={styles.inputs}>
          <TextInput
            style={styles.textInput}
            defaultValue="Email"
          />
          <TextInput
            style={styles.textInput}
            defaultValue="Senha"
          />
        </View>

        <View style={styles.buttonsLogin}>
          <View style={styles.password}>
            <Button
              title="Esqueci a Senha"
              onPress={handleSignIn} />
          </View>

          <View style={styles.buttonEnter}>
            <ButtonEnter
              title="Entrar"
              onPress={handleSignIn}
            />
          </View>
        </View>

        <View style={styles.buttonSocialMidia}>
          <ButtonGoogle />
          <ButtonFacebook />
          <ButtonICloud />
        </View>

        <View></View>

      </View>
    </Background>

  );

}