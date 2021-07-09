import React from 'react';

import {
  View,
  Text
} from 'react-native';
import { theme } from '../global/styles/theme';

import { styles } from './styles';

export function Menu() {
  return (
    <View style={styles.container}>
      <Text>Opção</Text>
      <Text>Opção</Text>
      <Text>Opção</Text>
      <Text>Opção</Text>
    </View>
  );
}