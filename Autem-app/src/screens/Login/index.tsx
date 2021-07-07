import React from "react";
import { View, Image } from "react-native";
import { Background } from "../../components/Background";
import { styles } from "./styles";
import Logo_Autem from '../../assets/logoAutem.png';

export function Login() {
  return (
    <Background>
      <View style={styles.container}>
        <View style={styles.containerLogo}>
          <Image
            source={Logo_Autem}
            style={styles.image}
            resizeMode="stretch"
          />
        </View>
      </View>
    </Background>

  );

}